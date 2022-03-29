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
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-PNAU4VT;Initial Catalog=EquipControl; Integrated Security=true"); //Параметры на подключение к базе данных
        public static string TablEquip = "Equip"; //Название таблицы
        public static string ColEquipId = "id"; //Название столбца номера оборудования
        public static string ColEquipTypeId = "EquipTypeId"; //Название столбца номера типа оборудования
        public static string ColNameEquip = "NameEquip"; //Название столбца названия оборудования
        public static string ColDayOf = "DayOf"; //Название столбца даты установки
        public static string ColAudienceNum = "AudienceNum"; //Название столбца номера аудитории

        public static string TablEquipType = "EquipType"; //Название таблицы по типу оборудования 

        public static string TablUsers = "users"; //Название таблицы пользователей
        public static string ColUserLogin = "usrlogin"; //Название столбца логина пользователя
        public static string ColUserPwd = "pwd"; //Название столбца пароля пользователя
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed) //Проверка на то закрыто ли подключение
            {
                sqlConnection.Open(); // Работа начинается. Подключение открывается
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open) //Проверска на то что подключение открыто
            {
                sqlConnection.Close(); //Закрытие подключения
            }
        }
        public SqlConnection getConnection() //Функия для получения состояния подключения
        {
            return sqlConnection;
        }
        public static DataTable fillingDataAdapter(string query) //Функция для заполнения данных полученных в результате запроса к базе данных
        {
            Database database = new Database();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand(query, database.getConnection());
            sqlDataAdapter.SelectCommand = command;
            try
            {
                sqlDataAdapter.Fill(table); //Заполнение переменной данными из запроса 
            }
            catch(SqlException sqlEx)
            {

            }
            return table;
        }
        public static List<Equip> queryFillingEquip(string query) //Функция заполнения списка оборудования
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
                equipsDataTable.Add(item); //Добавление объекта оборудования в список
            }
            getNameEquipType(equipsDataTable); //Переделывание типа оборудования с номера в название
            return equipsDataTable;
        }
        public static void runQuerty(string query) //Функция для простого выполнения запроса к базе данных
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
        public static List<EquipType> getListEquipType(string query) //Функция для получения списка оборудования
        {
            List<EquipType> equipTypes = new List<EquipType>(); //Список всего оборудования
            DataTable dataTable = fillingDataAdapter(query); //Данные из запроса
            EquipType elem;
            for (int index = 0; index < dataTable.Rows.Count; ++index)
            {
                elem = new EquipType();
                elem.id = int.Parse(dataTable.Rows[index][0].ToString());
                elem.name = dataTable.Rows[index][1].ToString();
                equipTypes.Add(elem); //Добавление элемента тип оборудования в список типов оборудований
            }
            return equipTypes;
        }
        public static int getIdForName(string nameType) //Получение по названию типа оборудования номер типа оборудования
        {
            List<EquipType> equipTypes = getListEquipType($"SELECT * FROM {TablEquipType}");
            foreach (var item in equipTypes)
            {
                if (item.name == nameType)
                {
                    return item.id;
                }
            }
            return -1;
        }
        private static void getNameEquipType(List<Equip> equips) //Замена номера типа оборудования
        {
            List<EquipType> equipTypes = getListEquipType($"SELECT * FROM {TablEquipType}"); //Получения данных из таблицы
            for (int indexEquip = 0; indexEquip < equips.Count; ++indexEquip)
            {
                equips[indexEquip].equipType = equipTypes[int.Parse(equips[indexEquip].equipType)].name;
            }
        }
    }
}
