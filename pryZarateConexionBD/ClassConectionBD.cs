using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace pryZarateConexionBD
{
    internal class ClassConectionBD
    {
        OleDbConnection conn;
        public void ConectarBD()
        {
            conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\..\\..\\BaseDatos\\baseJuegoRPG.accdb"; 
            conn.Open();

    }
    }
}