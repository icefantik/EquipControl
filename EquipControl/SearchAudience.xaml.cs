﻿using System;
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
            updateEquipsTable();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            audienceNumber = txtBoxAudienceNum.Text;
            if (audienceNumber.Length > 0)
            {
                updateEquipsTable();
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
            }
        }
        private void DelElemFromTable(object sender, RoutedEventArgs e)
        {
            string numEquip = txtBoxNumEquip.Text;
            string query = $"DELETE FROM {Database.TablEquip} WHERE {Database.ColEquipId} = {numEquip}";
            Database.runQuerty(query);
            updateEquipsTable(); //Обновление всей таблицы
        }
        private void OpenWindowAddElem(object sender, RoutedEventArgs e)
        {
            AddElemWindow addElemWindow = new AddElemWindow();
            addElemWindow.Owner = this;
            addElemWindow.Show();
        }
        private void updateEquipsTable() {
            string query;
            if (audienceNumber != null) {
                query = $"SELECT * FROM {Database.TablEquip} WHERE AudienceNum = {audienceNumber}";
            } 
            else {
                query = $"SELECT * FROM {Database.TablEquip}";
            }
            List<Equip> equips = Database.queryFillingEquip(query);
            equipGrid.ItemsSource = equips;
        }
    }
}
