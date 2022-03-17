using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipControl
{
    class Database
    {
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-PNAU4VT;Initial Catalog=EquipControl; Integrated Security=true");
        public static string TablEquip = "Equip";
        public static string ColEquipId = "id";
        public static string ColEquipTypeId = "EquipTypeId";
        public static string ColNameEquip = "NameEquip";
        public static string ColDayOf = "DayOf";
        public static string ColAudienceNum = "AudienceNum";

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
        public static DataTable fillingDataAdapter(string query)
        {
            Database database = new Database();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand(query, database.getConnection());
            sqlDataAdapter.SelectCommand = command;
            sqlDataAdapter.Fill(table);
            return table;
        }
        public static List<Equip> queryFillingEquip(string query)
        {
            DataTable dataTable = fillingDataAdapter(query);
            List<Equip> equipsDataTable = new List<Equip>();
            for (int index = 0; index < dataTable.Rows.Count; ++index)
            {
                Equip item = new Equip();
                item.id = int.Parse(dataTable.Rows[index][0].ToString());
                item.equipType = dataTable.Rows[index][1].ToString();
                item.name = dataTable.Rows[index][2].ToString();
                item.DayOf = dataTable.Rows[index][3].ToString();
                item.AudienceNum = int.Parse(dataTable.Rows[index][4].ToString());
                equipsDataTable.Add(item);
            }
            return equipsDataTable;
        }

        public static void runQuerty(string query)
        {
            Database database = new Database();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(query, database.getConnection());
            sqlDataAdapter.SelectCommand = command;
            sqlDataAdapter.Fill(table);
        }
    }
}
