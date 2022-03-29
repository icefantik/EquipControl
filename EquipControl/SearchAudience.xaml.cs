using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace EquipControl
{
    /// <summary>
    /// Логика взаимодействия для SearchAudience.xaml
    /// </summary>
    public partial class SearchAudience : Window
    {
<<<<<<< HEAD
        private static string audienceNumber = null; //Номер аудитории
        public SearchAudience()
        {
            InitializeComponent();
            updateEquipsTable(); //Заполнение таблици всем списком оборудования
        }

        private void Search(object sender, RoutedEventArgs e) //Функция срабатывает при нажатии на кнопку Поиск
        {
            audienceNumber = txtBoxAudienceNum.Text; //Текст номера аудитории
            if (audienceNumber.Length > 0) //Проверка, что поле для ввода не пустое
            {
                updateEquipsTable(); //Заполнение таблици по номеру аудитории
=======
        private static string audienceNumber = null; // Номер аудитории
        public SearchAudience()
        {
            InitializeComponent();
            updateEquipsTable(); // Заполнение таблици всем списком оборудования
        }

        private void Search(object sender, RoutedEventArgs e) // Функция срабатывает при нажатии на кнопку Поиск
        {
            audienceNumber = txtBoxAudienceNum.Text; // Текст номера аудитории
            if (audienceNumber.Length > 0) // Проверка, что поле для ввода не пустое
            {
                updateEquipsTable(); // Заполнение таблици по номеру аудитории
>>>>>>> 5fabda6436348ea7751ef0d20e17b7a2b4555cd5
            }
            else
            {
                Message.ShowMessage("Введите номер аудитории", "Warning");
            }
        }
<<<<<<< HEAD
        private void SaveTable(object sender, RoutedEventArgs e) //Функция сохраняющая изменения
=======
        private void SaveTable(object sender, RoutedEventArgs e) // Функция сохраняющая изменения
>>>>>>> 5fabda6436348ea7751ef0d20e17b7a2b4555cd5
        {
            var len = equipGrid.Items.Count - 1;
            foreach (var item in equipGrid.Items.OfType<Equip>())
            {
                Database.runQuerty($"update {Database.TablEquip} set {Database.ColEquipId} = {item.id}, " +
                    $"{Database.ColEquipTypeId} = {Database.getIdForName(item.equipType)}, " +
                    $"{Database.ColNameEquip} = \'{item.name}\', " +
                    $"{Database.ColDayOf} = \'{item.DayOf}\', " +
                    $"{Database.ColAudienceNum} = {item.AudienceNum} " +
<<<<<<< HEAD
                    $"WHERE {Database.ColEquipId} = {item.id}"); //Обновление всех элементов таблицы
            }
        }
        private void DelElemFromTable(object sender, RoutedEventArgs e) //Функция для удаления элемента
        {
            string numEquip = txtBoxNumEquip.Text; //Номер оборудования
            string query = $"DELETE FROM {Database.TablEquip} WHERE {Database.ColEquipId} = {numEquip}"; //Запрос на поиск оборудования и удаления его
            Database.runQuerty(query); //Исполнение запроса
=======
                    $"WHERE {Database.ColEquipId} = {item.id}"); // Обновление всех элементов таблицы
            }
        }
        private void DelElemFromTable(object sender, RoutedEventArgs e) // Функция для удаления элемента
        {
            string numEquip = txtBoxNumEquip.Text; // Номер оборудования
            string query = $"DELETE FROM {Database.TablEquip} WHERE {Database.ColEquipId} = {numEquip}"; // Запрос на поиск оборудования и удаления его
            Database.runQuerty(query); // Исполнение запроса
>>>>>>> 5fabda6436348ea7751ef0d20e17b7a2b4555cd5
            updateEquipsTable(); //Обновление всей таблицы
        }
        private void OpenWindowAddElem(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            AddElemWindow addElemWindow = new AddElemWindow(); //Создание нового обекта окна
            addElemWindow.Owner = this;
            addElemWindow.Show(); //Открытие окна
=======
            AddElemWindow addElemWindow = new AddElemWindow(); // Создание нового обекта окна
            addElemWindow.Owner = this;
            addElemWindow.Show(); // Открытие окна
>>>>>>> 5fabda6436348ea7751ef0d20e17b7a2b4555cd5
        }
        private void updateEquipsTable() {
            string query;
            if (audienceNumber != null) {
<<<<<<< HEAD
                query = $"SELECT * FROM {Database.TablEquip} WHERE AudienceNum = {audienceNumber}"; //Вывод оборудования по номеру аудитории
            } 
            else {
                query = $"SELECT * FROM {Database.TablEquip}"; //Вывод всего оборудования
=======
                query = $"SELECT * FROM {Database.TablEquip} WHERE AudienceNum = {audienceNumber}"; // Вывод оборудования по номеру аудитории
            } 
            else {
                query = $"SELECT * FROM {Database.TablEquip}"; // Вывод всего оборудования
>>>>>>> 5fabda6436348ea7751ef0d20e17b7a2b4555cd5
            }
            List<Equip> equips = Database.queryFillingEquip(query);
            equipGrid.ItemsSource = equips; //Заполняем таблицу данными получеными из запроса
        }
    }
}
