using System;
using System.Drawing;
using System.Windows.Forms;

namespace pryZarateConexionBD
{
    public partial class frmInicioSesion : Form
    {
        private int intentosFallidos = 0; // Contador de intentos fallidos.
        private const int MaxIntentos = 3; // Maximo de intentos antes de bloquear.

        public frmInicioSesion()
        {
            InitializeComponent();
            lblError.Text = string.Empty; // Arranco sin mensaje de error visible.
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            CargarCredencialesDeAyuda(); // Cuando se abre el form, cargo la grilla de ayuda con los mails y contraseñas.
        }

        private void CargarCredencialesDeAyuda()
        {
            try
            {
                dgvCredenciales.DataSource = BaseDatos.ObtenerCredenciales();
            }
            catch
            {
                // Si falla, no hago nada (la grilla queda vacia, no es critico).
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (intentosFallidos >= MaxIntentos) // Si ya gasto los 3 intentos, no le dejo seguir.
            {
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = "Cuenta bloqueada por demasiados intentos.";
                return;
            }

            string mail = txtMail.Text.Trim();
            string password = txtContraseña.Text;

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
            {
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = "Debe completar mail y contraseña.";
                return;
            }

            string error;
            bool ok = BaseDatos.ValidarUsuario(mail, password, out error);
            // Le pido a BaseDatos que verifique si existe el usuario con esa contraseña.

            if (ok)
            {
                lblError.ForeColor = Color.LimeGreen;
                lblError.Text = "Ingreso correcto. Bienvenido.";
                this.Hide(); // Escondo el login.
                using (var principal = new frmPrincipal())
                {
                    principal.ShowDialog(); // Abro la ventana principal en modo bloqueante.
                }
                this.Close(); // Al cerrar la principal, cierro el login (termina la app).
            }
            else
            {
                intentosFallidos++; // Sumo un intento fallido.
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = error ?? "Mail o contraseña incorrecta.";

                if (intentosFallidos >= MaxIntentos)
                {
                    lblError.Text = "Cuenta bloqueada tras 3 intentos fallidos.";
                    btnAceptar.Enabled = false; // Deshabilito el boton.
                }
            }
        }
    }
}
