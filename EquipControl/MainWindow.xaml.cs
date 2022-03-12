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
            string textLogin = txtBoxLogin.Text;
            string textPwd = textBoxPwd.Password;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"SELECT {Database.ColUserLogin}, {Database.ColUserPwd} FROM {Database.TablUsers} WHERE {Database.ColUserLogin} = \'{textLogin}\'";
            SqlCommand command = new SqlCommand(query, database.getConnection());
            sqlDataAdapter.SelectCommand = command;
            sqlDataAdapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                if (textLogin == table.Rows[0][0].ToString() && textPwd == table.Rows[0][1].ToString()) {
                    this.Hide(); //Закрытие MainWindow
                    SearchAudience searchAudience = new SearchAudience();
                    searchAudience.Owner = this;
                    searchAudience.Show(); //Переход на новое окно
                } else {
                    Message.ShowMessage("Введён неправильный логин или пароль", "Warning");
                }
            }
            else
            {
                Message.ShowMessage("Введён неправильный логин или пароль", "Warning");
            }
        }
    }
}
