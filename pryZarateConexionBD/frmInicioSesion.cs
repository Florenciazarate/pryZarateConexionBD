using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryZarateConexionBD
{
    public partial class frmInicioSesion : Form
    {
        private ClassConectionBD objConectarBD;
        private int intentosFallidos = 0;
        private const int MaxIntentos = 3;

        public frmInicioSesion()
        {
            InitializeComponent();
            lblError.Text = string.Empty;
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            objConectarBD = new ClassConectionBD();
            CargarUsuarios();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (intentosFallidos >= MaxIntentos)
            {
                lblError.Text = "Cuenta bloqueada por demasiados intentos.";
                return;
            }

            string mail = txtMail.Text.Trim();
            string password = txtContraseña.Text; 

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Debe completar mail y contraseña.";
                return;
            }

            try
            {
                string error;
                bool ok = objConectarBD.TryValidateUser(mail, password, out error);
                if (ok)
                {
                    lblError.ForeColor = Color.Green;
                    lblError.Text = "Ingreso correcto. Bienvenido.";
                }
                else
                {
                    intentosFallidos++;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = error ?? "Mail o contraseña incorrecta.";

                    if (intentosFallidos >= MaxIntentos)
                    {
                        lblError.Text = "Cuenta bloqueada tras 3 intentos fallidos.";
                        btnAceptar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Error al conectar/validar: " + ex.Message;
            }
        }
        private void CargarUsuarios()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" 
                          + Application.StartupPath
                          + @"\..\..\BaseDatos\basejuegoRPG.accdb";
            string query = "SELECT mail, contraseña FROM jugador";

            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPrueba.DataSource = dt;
            }
        }
    }
}
