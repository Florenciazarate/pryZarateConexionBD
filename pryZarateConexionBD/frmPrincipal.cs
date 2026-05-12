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
            InitializeComponent(); // Crea los controles visuales del formulario.
        }

        private void frmPrincipal_Load(object sender, EventArgs e) // Se ejecuta cuando se abre la ventana principal.
        {
            string error;
            if (BaseDatos.ProbarConexion(out error)) // Pruebo si me puedo conectar a la base.
            {
                lblEstadoConexion.ForeColor = Color.LimeGreen; // Pongo el label en verde.
                lblEstadoConexion.Text = "Conectado a la base de datos correctamente."; // Mensaje de éxito.

                DataTable jugadores = BaseDatos.ObtenerJugadores(); // Pido a BaseDatos todos los jugadores.
                dgvJugadores.DataSource = jugadores; // Los muestro en la grilla.
            }
            else
            {
                lblEstadoConexion.ForeColor = Color.IndianRed; // Pongo el label en rojo.
                lblEstadoConexion.Text = "Error al conectar: " + error; // Muestro el mensaje de error.
            }
        }
    }
}
