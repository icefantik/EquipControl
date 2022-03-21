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
            getList();
        }
        private void getList()
        {
            List<EquipType> equipTypes = Database.getListEquipType($"select * from {Database.TablEquipType}");
            foreach (var item in equipTypes) {
                typeComboBox.Items.Add($"{item.id}: {item.name}");
            }
        }
        private void AddElem(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[0-9]+");
            MatchCollection matches = regex.Matches(typeComboBox.Text);
            if (matches.Count > 0)
            {
                string id = idTextBox.Text, typeId = matches[0].ToString(), name = nameTextBox.Text, date = dateTextBox.Text, audience = audienceNumTextBox.Text;
                string query = $"insert into {Database.TablEquip} (id, EquipTypeId, NameEquip, DayOf, AudienceNum) values({id}, {typeId}, \'{name}\', \'{date}\', {audience})";
                Database.runQuerty(query);
                this.Hide();
            } 
            else
            {
                Message.ShowMessage("Выберите тип оборудования", "Warning");
            }
        }
    }
}
