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
        public SearchAudience()
        {
            InitializeComponent();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string audienceNumber = txtBoxAudienceNum.Text;
            string query = $"SELECT * FROM Equip WHERE AudienceNum = {audienceNumber}";
            List<Equip> equips = Database.queryFillingEquip(query);
            equipGrid.ItemsSource = equips;
        }
    }
}
