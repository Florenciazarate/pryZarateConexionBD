using System;
using System.Windows.Forms;

namespace pryZarateConexionBD
{
    internal static class Program
    {
        [STAThread] // Marca obligatoria para apps con ventanas en Windows.
        static void Main() // Punto de entrada de la app.
        {
            Application.EnableVisualStyles(); // Activa los estilos visuales modernos de Windows.
            Application.SetCompatibleTextRenderingDefault(false); // Usa el renderizado nuevo de texto.

            BaseDatos.EnsureConfigured(); // Configuro |DataDirectory| antes de abrir cualquier ventana, así la base se busca en la carpeta del proyecto.

            Application.Run(new frmInicioSesion()); // Abro la ventana de login. Mientras esté abierta, la app sigue corriendo.
        }
    }
}
