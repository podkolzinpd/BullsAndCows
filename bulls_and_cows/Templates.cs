using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace bulls_and_cows
{
    /// <summary>
    /// Класс со static функциями для множественного использования при создании иконок, подсказок и изменении цвета текста
    /// </summary>
    class Templates
    {
        /// <summary>
        /// Создание иконки
        /// </summary>
        /// <param name="name">Название иконки</param>
        /// <returns>Возвращает иконку быка/коровы/разделителя в зависимости от name</returns>
        public static BitmapImage _Image(string name)
        {
            string imagePath = @"..\..\images\" + name;
            Uri uri = new Uri(imagePath, UriKind.Relative);
            BitmapImage bi = new BitmapImage(uri);
            return bi;
        }

        /// <summary>
        /// Создание цвета текста
        /// </summary>
        /// <param name="value">Количество быков/коров</param>
        /// <returns>Если value - четное, то цвет - красный, иначе - черный</returns>
        public static Brush _Color(int value)
        {
            Brush col = Brushes.Black;
            if ((value % 2) == 0)
            {
                col = Brushes.Red;
            }
            return col;
        }

        /// <summary>
        /// Создание подсказки при наведении на иконку быка/коровы
        /// </summary>
        /// <param name="sign">Если true - бык, иначе - корова</param>
        /// <param name="value">Количество быков/коровы</param>
        /// <returns>Возвращает текст с количеством быков/коров</returns>
        public static string _ToolTip(bool sign, int value)
        {
            string tt = "";
            if (sign == true)
            {
                if (value == 0)
                {
                    tt = "В этом числе 0 быков";
                }
                else if (value == 1)
                {
                    tt = "В этом числе 1 бык";
                }
                else
                {
                    tt = "В этом числе " + value + " быка";
                }
            }
            else
            {
                if (value == 0)
                {
                    tt = "В этом числе 0 коров";
                }
                else if (value == 1)
                {
                    tt = "В этом числе 1 корова";
                }
                else
                {
                    tt = "В этом числе " + value + " коровы";
                }
            }

            return tt;
        }
    }
}