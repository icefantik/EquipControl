using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipControl
{
    class Database
    {
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-PNAU4VT;Initial Catalog=EquipControl; Integrated Security=true");
        public static string TablUsers = "users";
        public static string ColUserLogin = "usrlogin";
        public static string ColUserPwd = "pwd";
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
