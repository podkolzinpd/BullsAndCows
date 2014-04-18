using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bulls_and_cows
{
    /// <summary>
    /// Перечисление возможных расположений элементов
    /// </summary>
    public enum TargetType
    {
        BullMore, CowMore, Equality, CowNull, BullNull, BullFour
    }

    /// <summary>
    /// Структура, содержащая данные о конкретном ходе (количество быков/коровы, число, тип расположения)
    /// </summary>
    public struct Data
    {
        int bulls;                          //< быки
        int cows;                           //< коровы
        string result;                      //< результат
        TargetType type;                    //< тип расположения элементов

        /// <summary>
        /// Конструктор, вызывающийся при окончании игры
        /// </summary>
        /// <param name="result">Загаданное число</param>
        public Data(string result)
        {
            this.bulls = 4;
            this.cows = 0;
            this.result = result;
            this.type = TargetType.BullFour;
        }

        /// <summary>
        /// Конструктор, вызывающийся при каждом ходе
        /// </summary>
        /// <param name="bulls">Количество быков</param>
        /// <param name="cows">Количество коров</param>
        /// <param name="result">Предложенный вариант числа</param>
        public Data(int bulls, int cows, string result)
        {
            this.bulls = bulls;
            this.cows = cows;
            this.result = result;
            if ((bulls > cows) && (cows != 0))
            {
                this.type = TargetType.BullMore;
            }
            else if ((cows > bulls) && (bulls != 0))
            {
                this.type = TargetType.CowMore;
            }
            else if (cows == bulls)
            {
                this.type = TargetType.Equality;
            }
            else if (cows == 0)
            {
                this.type = TargetType.CowNull;
            }
            else if (bulls == 0)
            {
                this.type = TargetType.BullNull;
            }
            else
            {
                this.type = TargetType.BullFour;
            }
        }

        /// <summary>
        /// Свойство задает или возвращает количество быков
        /// </summary>
        public int Bull
        {
            get { return bulls; }
            set { bulls = value; }
        }

        /// <summary>
        /// Свойство задает или возвращает количество коров
        /// </summary>
        public int Cow
        {
            get { return cows; }
            set { cows = value; }
        }

        /// <summary>
        /// Свойство задает или возвращает текущее число
        /// </summary>
        public string Res
        {
            get { return result; }
            set { result = value; }
        }

        /// <summary>
        /// Свойство задает или возвращает текущий тип расположения элементов
        /// </summary>
        public TargetType TarType
        {
            get { return type; }
            set { type = value; }
        }
    }
}
