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
    /// Логика взаимодействия для AddElemWindow.xaml
    /// </summary>
    public partial class AddElemWindow : Window
    {
        public AddElemWindow()
        {
            InitializeComponent();
        }
        private void AddElem(object sender, RoutedEventArgs e)
        {
            string id = idTextBox.Text, typeId = typeTextBox.Text, name = nameTextBox.Text, date = dateTextBox.Text, audience = audienceNumTextBox.Text;
            string query = $"insert into Equip (id, EquipTypeId, NameEquip, DayOf, AudienceNum)values({id}, {typeId}, '{name}', '{date}', {audience}); ";
            Database.runQuerty(query);
        }
    }
}
