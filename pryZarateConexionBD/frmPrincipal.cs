using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryZarateConexionBD
{
    public partial class frmPrincipal : Form
    {
        private ClassConectionBD objConectarBD;

        public frmPrincipal()
        {
            InitializeComponent();
        }
      
        private void frmPrincipal_Load_1(object sender, EventArgs e)
        {
            objConectarBD = new ClassConectionBD();
            try
            {
                objConectarBD.ConectarBD();
                lblEstadoConexión.BackColor = Color.Green;
                lblEstadoConexión.Text = "Ningun error al conectar a la base de datos";

                // Obtener datos y asignarlos a la grilla
                DataTable dt = objConectarBD.ObtenerTablaPrincipal();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                lblEstadoConexión.BackColor = Color.Red;
                lblEstadoConexión.Text = "Error al conectar a la base de datos: " + ex.Message;
            }
            finally
            {
                // La grilla muestra los datos en memoria, podemos cerrar la conexión
                try { objConectarBD?.CerrarBD(); } catch { }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
