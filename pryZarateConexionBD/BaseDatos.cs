using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace pryZarateConexionBD
{
    // Centraliza el acceso a la base de datos: conexión, validación de usuarios y consultas.
    public static class BaseDatos
    {
        private static string GetConnectionString() // Devuelve un texto con la dirección de conexión.
        {
            return ConfigurationManager.ConnectionStrings["JuegoRPG"].ConnectionString;
            // Devuelve la cadena de conexión llamada "JuegoRPG" que está guardada en App.config.
        }

        public static void EnsureConfigured() // Configura la ruta donde la app va a buscar la base.
        {
            var projectDir = GetProjectDirectory(); // Guardo la carpeta del proyecto.
            AppDomain.CurrentDomain.SetData("DataDirectory", projectDir);
            // Defino que la variable "DataDirectory" del App.config valga la carpeta del proyecto.
        }

        private static string GetProjectDirectory() // Devuelve la ruta de la carpeta del proyecto.
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory); // Empiezo en la carpeta del .exe.
            while (dir != null) // Mientras haya una carpeta padre donde mirar, sigo.
            {
                if (dir.GetFiles("*.csproj").Length > 0)
                    return dir.FullName; // Si encuentro un .csproj, esta es la carpeta del proyecto.
                dir = dir.Parent; // Sino, subo una carpeta y vuelvo a probar.
            }
            return AppDomain.CurrentDomain.BaseDirectory; // Si no encontré el .csproj, devuelvo la carpeta del .exe como respaldo.
        }

        public static bool ValidarUsuario(string mail, string password, out string errorMessage)
        // Recibe mail y contraseña, devuelve true/false si existen en la base. El mensaje de error sale por errorMessage.
        {
            errorMessage = null; // Arranco sin error.

            try
            {
                using (var conn = new OleDbConnection(GetConnectionString())) // Creo la conexión, se cierra sola.
                using (var cmd = new OleDbCommand("SELECT COUNT(*) FROM jugador WHERE mail = ? AND contraseña = ?", conn))
                // Creo un comando que cuenta cuántos jugadores tienen ese mail y contraseña.
                {
                    cmd.Parameters.AddWithValue("@mail", mail); // Le paso el mail como parámetro.
                    cmd.Parameters.AddWithValue("@pass", password); // Le paso la contraseña como parámetro.
                    conn.Open(); // Abro la conexión.
                    int count = Convert.ToInt32(cmd.ExecuteScalar()); // Ejecuto la consulta y guardo el conteo.
                    if (count > 0) return true; // Si hay al menos uno, el usuario es válido.

                    errorMessage = "Mail o contraseña incorrecta."; // Sino, marco el error.
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error al validar usuario: " + ex.Message; // Si algo falla, guardo el mensaje de error.
                return false;
            }
        }

        public static DataTable ObtenerCredenciales() // Devuelve una tabla con los mails y contraseñas (para la grilla de ayuda del login).
        {
            var table = new DataTable(); // Tabla vacía.
            using (var conn = new OleDbConnection(GetConnectionString())) // Creo la conexión, se cierra sola.
            using (var da = new OleDbDataAdapter("SELECT mail, contraseña FROM jugador", conn))
            // Creo un adaptador que ejecuta el SELECT.
            {
                da.Fill(table); // Lleno la tabla con los resultados.
            }
            return table; // Devuelvo la tabla.
        }

        public static DataTable ObtenerJugadores() // Devuelve una tabla con TODOS los datos de la tabla jugador.
        {
            var table = new DataTable(); // Tabla vacía.
            using (var conn = new OleDbConnection(GetConnectionString())) // Creo la conexión.
            using (var da = new OleDbDataAdapter("SELECT * FROM jugador", conn)) // Adaptador con el SELECT completo.
            {
                da.Fill(table); // Lleno la tabla.
            }
            return table;
        }

        public static bool ProbarConexion(out string errorMessage) // Intenta abrir la conexión. Devuelve true si funcionó.
        {
            errorMessage = null;
            try
            {
                using (var conn = new OleDbConnection(GetConnectionString()))
                {
                    conn.Open(); // Si esto no falla, la conexión es válida.
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message; // Si falla, guardo el mensaje.
                return false;
            }
        }
    }
}
