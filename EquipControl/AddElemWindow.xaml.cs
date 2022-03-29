using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EquipControl
{
    /// <summary>
    /// Логика взаимодействия для AddElemWindow.xaml
    /// </summary>
    public partial class AddElemWindow : Window
    {
        public AddElemWindow()
        {
            InitializeComponent();
            getList(); //Заполнение выпадающего списка типа оборудования
        }
        private void getList() //Функция для заполения выпадающего списка
        {
            List<EquipType> equipTypes = Database.getListEquipType($"select * from {Database.TablEquipType}"); //Данные из таблици базы данных
            foreach (var item in equipTypes) {
                typeComboBox.Items.Add($"{item.id}: {item.name}"); //Заполнение выпадающего списка
            }
        }
        private void AddElem(object sender, RoutedEventArgs e) //Добавление элемента в базу данных
        {
            Regex regex = new Regex("[0-9]+"); //Номер для текста из выпадающего списка 
            MatchCollection matches = regex.Matches(typeComboBox.Text);
            if (matches.Count > 0) //Тип оборудования в выпадающем списке не выбран
            {
                string id = idTextBox.Text, typeId = matches[0].ToString(), name = nameTextBox.Text, date = dateTextBox.Text, audience = audienceNumTextBox.Text; //Получение данных об оборудовании из полей для ввода
                string query = $"insert into {Database.TablEquip} (id, EquipTypeId, NameEquip, DayOf, AudienceNum) values({id}, {typeId}, \'{name}\', \'{date}\', {audience})"; //Формирование запроса
                Database.runQuerty(query); //Исполение запроса
                this.Hide(); //Закрытие окна
            } 
            else
            {
                Message.ShowMessage("Выберите тип оборудования", "Warning"); //Вывод сообщения об ошибке
            }
        }
    }
}
