using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipControl
{
    class Equip
    {
        public int id { get; set; } //Номер оборудования
        public string equipType { get; set; } //Тип оборудования
        public string name { get; set; } //Название оборудования
        public string DayOf { get; set; } //Дата установки
        public int AudienceNum { get; set; } //Номер аудитории
    }
}
