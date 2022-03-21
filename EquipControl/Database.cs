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

        public static string TablEquipType = "EquipType";

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
            try
            {
                sqlDataAdapter.Fill(table);
            }
            catch(SqlException sqlEx)
            {

            }
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
            getNameEquipType(equipsDataTable);
            return equipsDataTable;
        }
        public static void runQuerty(string query)
        {
            Database database = new Database();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(query, database.getConnection());
            sqlDataAdapter.SelectCommand = command;
            try
            {
                sqlDataAdapter.Fill(table);
            }
            catch (SqlException sqlEx)
            {

            }
        }
        public static List<EquipType> getListEquipType(string query)
        {
            List<EquipType> equipTypes = new List<EquipType>();
            DataTable dataTable = fillingDataAdapter(query);
            EquipType elem;
            for (int index = 0; index < dataTable.Rows.Count; ++index)
            {
                elem = new EquipType();
                elem.id = int.Parse(dataTable.Rows[index][0].ToString());
                elem.name = dataTable.Rows[index][1].ToString();
                equipTypes.Add(elem);
            }
            return equipTypes;
        }
        private static void getNameEquipType(List<Equip> equips)
        {
            List<EquipType> equipTypes = getListEquipType($"SELECT * FROM {TablEquipType}");
            for (int indexEquip = 0; indexEquip < equips.Count; ++indexEquip)
            {
                equips[indexEquip].equipType = equipTypes[int.Parse(equips[indexEquip].equipType)].name;
            }
        }
    }
}
