using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace pryZarateConexionBD
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            string error;
            if (BaseDatos.ProbarConexion(out error)) // Pruebo la conexion a la base.
            {
                lblEstadoConexion.ForeColor = Color.LimeGreen;
                lblEstadoConexion.Text = "Conectado a la base de datos correctamente.";

                DataTable jugadores = BaseDatos.ObtenerJugadores(); // Traigo todos los jugadores.
                dgvJugadores.DataSource = jugadores; // Los muestro en la grilla.
            }
            else
            {
                lblEstadoConexion.ForeColor = Color.IndianRed;
                lblEstadoConexion.Text = "Error al conectar: " + error;
            }
        }
    }
}
