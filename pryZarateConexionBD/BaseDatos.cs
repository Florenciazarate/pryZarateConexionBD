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
        // Lee la cadena de conexión desde App.config.
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JuegoRPG"].ConnectionString;
        }

        // Configura |DataDirectory| para que apunte a la carpeta del proyecto, no a bin/Debug.
        public static void EnsureConfigured()
        {
            var projectDir = GetProjectDirectory();
            AppDomain.CurrentDomain.SetData("DataDirectory", projectDir);
        }

        // Sube desde bin/Debug buscando el .csproj para ubicar la carpeta del proyecto.
        private static string GetProjectDirectory()
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            while (dir != null)
            {
                if (dir.GetFiles("*.csproj").Length > 0)
                    return dir.FullName;
                dir = dir.Parent;
            }
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        // Valida que existan el mail y la contraseña en la tabla jugador.
        public static bool ValidarUsuario(string mail, string password, out string errorMessage)
        {
            errorMessage = null;

            try
            {
                using (var conn = new OleDbConnection(GetConnectionString()))
                using (var cmd = new OleDbCommand("SELECT COUNT(*) FROM jugador WHERE mail = ? AND contraseña = ?", conn))
                {
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@pass", password);
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0) return true;

                    errorMessage = "Mail o contraseña incorrecta.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error al validar usuario: " + ex.Message;
                return false;
            }
        }

        // Devuelve solo mail y contraseña, para mostrar como ayuda en el login.
        public static DataTable ObtenerCredenciales()
        {
            var table = new DataTable();
            using (var conn = new OleDbConnection(GetConnectionString()))
            using (var da = new OleDbDataAdapter("SELECT mail, contraseña FROM jugador", conn))
            {
                da.Fill(table);
            }
            return table;
        }

        // Devuelve todos los jugadores de la tabla, para mostrar en la grilla.
        public static DataTable ObtenerJugadores()
        {
            var table = new DataTable();
            using (var conn = new OleDbConnection(GetConnectionString()))
            using (var da = new OleDbDataAdapter("SELECT * FROM jugador", conn))
            {
                da.Fill(table);
            }
            return table;
        }

        // Prueba si se puede abrir la conexión a la base.
        public static bool ProbarConexion(out string errorMessage)
        {
            errorMessage = null;
            try
            {
                using (var conn = new OleDbConnection(GetConnectionString()))
                {
                    conn.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
