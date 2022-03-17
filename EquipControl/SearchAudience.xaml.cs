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
        private static string audienceNumber = null;
        public SearchAudience()
        {
            InitializeComponent();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            audienceNumber = txtBoxAudienceNum.Text;
            if (audienceNumber.Length > 0)
            {
                string query = $"SELECT * FROM Equip WHERE AudienceNum = {audienceNumber}";
                List<Equip> equips = Database.queryFillingEquip(query);
                equipGrid.ItemsSource = equips;
            }
            else
            {
                Message.ShowMessage("Введите номер аудитории", "Warning");
            }
        }
        private void SaveTable(object sender, RoutedEventArgs e)
        {
            var len = equipGrid.Items.Count - 1;
            foreach (var item in equipGrid.Items.OfType<Equip>())
            {
                Database.runQuerty($"update {Database.TablEquip} set {Database.ColEquipId} = {item.id}, " +
                    $"{Database.ColEquipTypeId} = {item.equipType}, " +
                    $"{Database.ColNameEquip} = \'{item.name}\', " +
                    $"{Database.ColDayOf} = \'{item.DayOf}\', " +
                    $"{Database.ColAudienceNum} = {item.AudienceNum} " +
                    $"WHERE {Database.ColEquipId} = {item.id}");
                /*
                if (numberElem != len)
                {
                    query += $"({item.id}, {item.equipType}, {item.name}, {item.DayOf}, {item.AudienceNum}),";
                }
                else
                {
                    query += $"({item.id}, {item.equipType}, {item.name}, {item.DayOf}, {item.AudienceNum})";
                }
                ++numberElem;
                */
            }
        }
    }
}
