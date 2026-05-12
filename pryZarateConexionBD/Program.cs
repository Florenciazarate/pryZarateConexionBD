using System;
using System.Windows.Forms;

namespace pryZarateConexionBD
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BaseDatos.EnsureConfigured(); // Configuro |DataDirectory| antes de abrir cualquier ventana.

            Application.Run(new frmInicioSesion());
        }
    }
}
