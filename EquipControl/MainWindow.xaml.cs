using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EquipControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database database = new Database();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void EnterAccount(object sender, RoutedEventArgs e)
        {
            string textLogin = txtBoxLogin.Text; //Текст из поля для ввода логина
            string textPwd = textBoxPwd.Password; //Текст из поля для ввода пароля
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(); // Переменная для подключения к базе данных и исполнения запроса
            DataTable table = new DataTable(); // Переменная для хранения таблицы из базы данных

            string query = $"SELECT {Database.ColUserLogin}, {Database.ColUserPwd} FROM {Database.TablUsers} WHERE {Database.ColUserLogin} = \'{textLogin}\'"; //Запрос на нахождение логина
            SqlCommand command = new SqlCommand(query, database.getConnection()); 
            sqlDataAdapter.SelectCommand = command; // Исполнение запроса к базе данных
            sqlDataAdapter.Fill(table); //Заполнение переменной данными из таблицы

            if (table.Rows.Count == 1) // Проверка получил ли пользователь один логин и пароль
            {
                if (textLogin == table.Rows[0][0].ToString() && textPwd == table.Rows[0][1].ToString()) { //Проверка на то что введённый логин и пароль совпадают с данными из базы данных
                    this.Hide(); //Закрытие MainWindow
                    SearchAudience searchAudience = new SearchAudience(); // Создание объекта для перехода на новое окно
                    searchAudience.Owner = this;
                    searchAudience.Show(); //Переход на новое окно
                } else {
                    Message.ShowMessage("Введён неправильный логин или пароль", "Warning"); // Сообщение о том что введён не правельный логин и пароль
                }
            }
            else
            {
                Message.ShowMessage("Введён неправильный логин или пароль", "Warning"); // Сообщение о том что введён не правельный логин и пароль
            }
        }
    }
}
