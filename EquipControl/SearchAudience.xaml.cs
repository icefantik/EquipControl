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
            }
            else
            {
                Message.ShowMessage("Введите номер аудитории", "Warning");
            }
        }
        private void SaveTable(object sender, RoutedEventArgs e) // Функция сохраняющая изменения
        {
            var len = equipGrid.Items.Count - 1;
            foreach (var item in equipGrid.Items.OfType<Equip>())
            {
                Database.runQuerty($"update {Database.TablEquip} set {Database.ColEquipId} = {item.id}, " +
                    $"{Database.ColEquipTypeId} = {Database.getIdForName(item.equipType)}, " +
                    $"{Database.ColNameEquip} = \'{item.name}\', " +
                    $"{Database.ColDayOf} = \'{item.DayOf}\', " +
                    $"{Database.ColAudienceNum} = {item.AudienceNum} " +
                    $"WHERE {Database.ColEquipId} = {item.id}"); // Обновление всех элементов таблицы
            }
        }
        private void DelElemFromTable(object sender, RoutedEventArgs e) // Функция для удаления элемента
        {
            string numEquip = txtBoxNumEquip.Text; // Номер оборудования
            string query = $"DELETE FROM {Database.TablEquip} WHERE {Database.ColEquipId} = {numEquip}"; // Запрос на поиск оборудования и удаления его
            Database.runQuerty(query); // Исполнение запроса
            updateEquipsTable(); //Обновление всей таблицы
        }
        private void OpenWindowAddElem(object sender, RoutedEventArgs e)
        {
            AddElemWindow addElemWindow = new AddElemWindow(); // Создание нового обекта окна
            addElemWindow.Owner = this;
            addElemWindow.Show(); // Открытие окна
        }
        private void updateEquipsTable() {
            string query;
            if (audienceNumber != null) {
                query = $"SELECT * FROM {Database.TablEquip} WHERE AudienceNum = {audienceNumber}"; // Вывод оборудования по номеру аудитории
            } 
            else {
                query = $"SELECT * FROM {Database.TablEquip}"; // Вывод всего оборудования
            }
            List<Equip> equips = Database.queryFillingEquip(query);
            equipGrid.ItemsSource = equips;
        }
    }
}
