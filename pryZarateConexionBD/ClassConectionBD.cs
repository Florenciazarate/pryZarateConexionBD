using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace pryZarateConexionBD
{
    internal class ClassConectionBD
    {
        private OleDbConnection conn;

        public void ConectarBD()
        {
            conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\..\\..\\BaseDatos\\baseJuegoRPG.accdb"; 
            conn.Open();
        }

        public DataTable ObtenerTablaPrincipal()
        {
            if (conn == null)
                ConectarBD();

            DataTable result = new DataTable();

            DataTable schema = conn.GetSchema("Tables");
            string tableName = null;
            foreach (DataRow row in schema.Rows)
            {
                string tableType = row["TABLE_TYPE"].ToString();
                string tName = row["TABLE_NAME"].ToString();
                if (tableType.Equals("TABLE", StringComparison.OrdinalIgnoreCase) && !tName.StartsWith("MSys", StringComparison.OrdinalIgnoreCase))
                {
                    tableName = tName;
                    break;
                }
            }

            if (string.IsNullOrEmpty(tableName))
                return result;

            string sql = $"SELECT * FROM [{tableName}]";
            using (OleDbDataAdapter da = new OleDbDataAdapter(sql, conn))
            {
                da.Fill(result);
            }

            return result;
        }

        public void CerrarBD()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }


        public bool TryValidateUser(string mail, string password, out string errorMessage)
        {
            errorMessage = null;
            try
            {
                if (conn == null)
                    ConectarBD();

                DataTable dt = ObtenerTablaPrincipal();
                if (dt == null || dt.Columns.Count == 0)
                {
                    errorMessage = "No se encontró la tabla de usuarios en la base de datos.";
                    return false;
                }

                string mailCol = null;
                string passCol = null;

                foreach (DataColumn col in dt.Columns)
                {
                    string name = col.ColumnName.ToLower();
                    if (mailCol == null && (name.Contains("mail") || name.Contains("email") || name.Contains("usuario") || name.Contains("user")))
                        mailCol = col.ColumnName;
                    if (passCol == null && (name.Contains("pass") || name.Contains("contr") || name.Contains("clave") || name.Contains("password")))
                        passCol = col.ColumnName;
                }

                if (mailCol == null || passCol == null)
                {
                    errorMessage = "No se encontraron las columnas de mail y/o contraseña en la tabla.";
                    return false;
                }

                foreach (DataRow row in dt.Rows)
                {
                    string dbMail = row[mailCol]?.ToString()?.Trim();
                    string dbPass = row[passCol]?.ToString()?.Trim();
                    if (string.Equals(dbMail, mail, StringComparison.OrdinalIgnoreCase) && dbPass == password)
                    {
                        return true;
                    }
                }

                errorMessage = "Mail o contraseña incorrecta.";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = "Error al validar usuario: " + ex.Message;
                return false;
            }
        }
    }
}


//try
//{
 //   conn = new OleDbConnection();
   // conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
     //   " Data Source=" + Application.StartupPath + "\\..\\..\\BaseDatos\\baseJuegoRPG.accdb";
    //conn.Open();

    //OleDbCommand cmd = new OleDbCommand();
    //cmd.Connection = conn;
   // cmd.CommandType = CommandType.TableDirect;
 //   cmd.CommandText = "jugador";

    //using (var cmd = new OleDbCommand("SELECT * FROM jugador", conn))

//    OleDbDataReader reader = cmd.ExecuteReader();

    //reader = cmd.ExecuteReader();

  //  if (reader.HasRows)
    //{
      //  while (reader.Read())
        //{
          //  if (usuario == reader.GetString(3) && contrasena == reader.GetString(2))
            //{
              //  MessageBox.Show("Bienvenido " + reader.GetString(2));
                //break;
            //}
        //}

//    }


  //  conn.Close();
//}
//catch (Exception error)
//{

//}