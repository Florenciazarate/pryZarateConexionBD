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
        public frmPrincipal()
        {
            InitializeComponent();
        }
      
        private void frmPrincipal_Load_1(object sender, EventArgs e)
        {
            ClassConectionBD objConectarBD = new ClassConectionBD();
            try
            {
                objConectarBD.ConectarBD();
                lblEstadoConexión.BackColor = Color.Green;
                lblEstadoConexión.Text = "Ningun error al conectar a la base de datos";
            }
            catch
            {
                lblEstadoConexión.BackColor = Color.Red;
                lblEstadoConexión.Text = "Error al conectar a la base de datos";

            }
private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 2. Configurar el comando para traer la tabla
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.TableDirect;
            cmd.CommandText = "La tabla";

            // 3. Usar el DataAdapter para llenar el DataSet
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds, "La tabla");

            // 4. Vincular el resultado a la grilla (DataGridView)
            // Las fuentes indican que al asignar el DataSource, las columnas se crean automáticamente
            dgvDatos.DataSource = ds.Tables["La tabla"];
        }
        catch (Exception ex) {
        MessageBox.Show("Error al cargar datos: " + ex.Message);
        }
    }
}
    
