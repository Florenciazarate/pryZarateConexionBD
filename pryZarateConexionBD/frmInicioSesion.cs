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
            InitializeComponent(); // Crea los controles visuales definidos en el Designer.
            lblError.Text = string.Empty; // Arranco sin mensaje de error visible.
        }

        private void frmInicioSesion_Load(object sender, EventArgs e) // Se ejecuta cuando se abre la ventana.
        {
            CargarCredencialesDeAyuda(); // Cargo la grilla de ayuda con los mails y contraseñas existentes.
        }

        private void CargarCredencialesDeAyuda() // Trae los mails y contraseñas de la base para mostrarlos en la grilla de ayuda.
        {
            try
            {
                dgvCredenciales.DataSource = BaseDatos.ObtenerCredenciales(); // Le pido a BaseDatos la lista y la pongo en la grilla.
            }
            catch
            {
                // Si falla (por ejemplo si no se puede conectar a la base), no hago nada. La grilla queda vacia, no es critico.
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e) // Se ejecuta al apretar el botón Ingresar.
        {
            if (intentosFallidos >= MaxIntentos) // Si ya gasto los 3 intentos, no le dejo seguir.
            {
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = "Cuenta bloqueada por demasiados intentos.";
                return;
            }

            string mail = txtMail.Text.Trim(); // Tomo el mail quitando espacios.
            string password = txtContraseña.Text; // Tomo la contraseña.

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password)) // Si alguno está vacío, error.
            {
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = "Debe completar mail y contraseña.";
                return;
            }

            string error;
            bool ok = BaseDatos.ValidarUsuario(mail, password, out error);
            // Le pido a BaseDatos que verifique si existe el usuario con esa contraseña. Si falla, "error" tiene el motivo.

            if (ok) // Si las credenciales son correctas...
            {
                lblError.ForeColor = Color.LimeGreen;
                lblError.Text = "Ingreso correcto. Bienvenido.";
                this.Hide(); // ...escondo el login.
                using (var principal = new frmPrincipal())
                {
                    principal.ShowDialog(); // Abro la ventana principal en modo bloqueante (espera a que se cierre).
                }
                this.Close(); // Al cerrar la principal, cierro el login (termina la app).
            }
            else // Si las credenciales son incorrectas...
            {
                intentosFallidos++; // ...sumo un intento fallido.
                lblError.ForeColor = Color.IndianRed;
                lblError.Text = error ?? "Mail o contraseña incorrecta."; // Muestro el error.

                if (intentosFallidos >= MaxIntentos) // Si ya gasto los 3 intentos, bloqueo el botón.
                {
                    lblError.Text = "Cuenta bloqueada tras 3 intentos fallidos.";
                    btnAceptar.Enabled = false;
                }
            }
        }
    }
}
