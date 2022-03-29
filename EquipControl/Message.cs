using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EquipControl
{
    class Message
    {
        public static void ShowMessage(string messageBoxText, string caption)
        {
            MessageBoxButton button = MessageBoxButton.OK; //Тип кнопки на окне сообщения
            MessageBoxImage icon = MessageBoxImage.Warning; //Тип картинки на окне сообщения

            MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes); //Вывод сообщения с такстом и типом окна
        }
    }
}
