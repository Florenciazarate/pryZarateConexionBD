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

        // Returns the first non-system table as a DataTable (or empty DataTable if none)
        public DataTable ObtenerTablaPrincipal()
        {
            if (conn == null)
                ConectarBD();

            DataTable result = new DataTable();

            // Get user tables from the database schema
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
    }
}