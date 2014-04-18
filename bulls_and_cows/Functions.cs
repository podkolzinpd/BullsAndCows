using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace bulls_and_cows
{
    /// <summary>
    /// Класс с основыми функциями алгоритма игры "Быки и коровы"
    /// </summary>
    class Functions
    {
        /// <summary>
        /// Отсеивание комбинаций из четырех разных цифр
        /// </summary>
        /// <param name="n1">Комбинация числа в массиве</param>
        /// <param name="n2">Возможная комбинация</param>
        /// <param name="bulls">Количество быков</param>
        /// <param name="cows">Количество коров</param>
        /// <returns>Если количества быков и коров равны количествам одинаковых </returns>
        static bool bolting(int n1, int n2, int bulls, int cows)
        {
            int count1 = 0;
            int count2 = 0;
            string str1 = "";
            string str2 = "";

            if (n1 < 1000)
            {
                str1 = "0" + n1.ToString();
                str2 = "0" + n2.ToString();
            }
            else if ((n1 >= 1000) && (n2 < 1000))
            {
                str1 = n1.ToString();
                str2 = "0" + n2.ToString();
            }
            else if ((n1 >= 1000) && (n2 >= 1000))
            {
                str1 = n1.ToString();
                str2 = n2.ToString();
            }
            for (int i = 0; i < 4; ++i)
            {
                if (str1[i] == str2[i])
                {
                    ++count1;
                }
                for (int j = 0; j < 4; ++j)
                {
                    if ((str1[i] == str2[j]) && (i != j))
                    {
                        ++count2;
                    }
                }
            }
            return ((bulls == count1) && (cows == count2));
        }

        /// <summary>
        /// Проверка комбинации цифр
        /// </summary>
        /// <param name="x">Число</param>
        /// <returns>Если число состоит из разных цифр - true, иначе - false</returns>
        static bool difNum(int x)
        {
            string str = "";
            if (x < 10)
            {
                str = "000" + x;
            }
            else if (x < 100)
            {
                str = "00" + x;
            }
            else if (x < 1000)
            {
                str = "0" + x;
            }
            else
            {
                str = x.ToString();
            }
            return ((int.Parse(str[0].ToString()) >= 0) && (int.Parse(str[0].ToString()) <= 9)
                && (str[0] != str[1]) && (str[0] != str[2]) && (str[0] != str[3])
                && (str[1] != str[2]) && (str[1] != str[3]) && (str[2] != str[3]));
        }

        /// <summary>
        /// Генерирование возможных комбинациий из четырех разных цифр
        /// </summary>
        /// <param name="arr">Массив типа bool со всеми возможными комбинациями</param>
        public static void fill(bool[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = !difNum(i);
            }
        }

        /// <summary>
        /// Угадывание числа
        /// </summary>
        /// <param name="number">Загаданное число</param>
        /// <param name="arr">Массив типа bool</param>
        /// <returns>Возвращает экземпляр структуры, содержащей информацию о текущем ходе</returns>
        public static Data solution(string number, bool[] arr)
        {
            int dB = 0;
            int dC = 0;
            string dRes = "";
            int num = 0;
            int count1 = 0;
            int count2 = 0;

            for (num = 0; num < arr.Length && arr[num]; ++num) { }

            if (num < 1000)
            {
                dRes = "0" + num.ToString();
            }
            else
            {
                dRes = num.ToString();
            }

            for (int i = 0; i < 4; ++i)
            {
                if (number[i] == dRes[i])
                {
                    ++count1;
                }
                for (int j = 0; j < 4; ++j)
                {
                    if ((number[i] == dRes[j]) && (i != j))
                    {
                        ++count2;
                    }
                }
            }

            dB = count1;
            dC = count2;

            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = arr[i] || !bolting(i, num, dB, dC);
            }
            return new Data(dB, dC, dRes);
        }
    }
}