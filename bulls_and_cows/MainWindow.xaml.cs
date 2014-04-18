////-----------------------------------------------------------------------
// <author>Подколзин Павел</author>
// <created>2013/03/23</created>
//-----------------------------------------------------------------------

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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result", typeof(string),
            typeof(MainWindow), new FrameworkPropertyMetadata());
        public string Result
        {
            get { return (string)this.GetValue(ResultProperty); }
            set { this.SetValue(ResultProperty, value); }
        }

        ObservableCollection<Data> statistics = new ObservableCollection<Data>();
        public ObservableCollection<Data> Results
        {
            get { return statistics; }
            set { statistics = value; }
        }

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register("Progress", typeof(string),
            typeof(MainWindow), new FrameworkPropertyMetadata());
        public string Progress
        {
            get { return (string)this.GetValue(ProgressProperty); }
            set { this.SetValue(ProgressProperty, value); }
        }

        public MainWindow()
        {
            Progress = "Порядковый номер хода 0";
            Result = "Введите число:";
            
            InitializeComponent();
        }

        int progress = 0;                           //< номер хода
        const int size = 10000;                     //< количество вариантов чисел
        bool signStartFinish = false;               //< признак определения окончания игры
        bool[] arr = new bool[size];                //< массив возможных варинтов чисел
        Data data;                                  //< результат текущего хода

        /// <summary>
        /// Класс вывода статистики
        /// </summary>
        class BullsCows
        {
            Data data;                                 //< текущий ход
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="d">Данные о текущем ходе</param>
            public BullsCows(Data d)
            {
                this.data = d;
            }

            /// <summary>
            /// Вывод статистики результатов
            /// </summary>
            /// <param name="statistics">Статистика результатов</param>
            public void print(ObservableCollection<Data> statistics)
            {
                // Добавление в список результатов

                statistics.Insert(0, data);
            }
        }

        /// <summary>
        /// Событие при нажатии на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ControlForCurRes.hiding();
            if ((data.Bull == 4) && (data.Cow == 0))
            {
                signStartFinish = false;
                data = default(Data);
                Result = "";
                statistics.Clear();
                progress = 0;
                Progress = "Порядковый номер хода " + progress.ToString();
            }
            else
            {
                ++progress;
                Progress = "Порядковый номер хода " + progress.ToString();
                if (signStartFinish == false)
                {
                    signStartFinish = true;
                    Functions.fill(arr);
                }
                if (Result.Length != 4)
                {
                    MessageBox.Show("Число должно состоять из 4 цифр!", "Ошибка");
                    Result = "Введите число:";
                }
                else
                {
                    data = Functions.solution(Result, arr);

                    ControlForCurRes.link(data);

                    BullsCows bc = new BullsCows(data);
                    bc.print(statistics);
                }
            }
        }

        /// <summary>
        /// Нажатие на левую кнопки мыши в TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Result = "";
        }

        /// <summary>
        /// Изменение текста в TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Result != "Введите число:")
            {
                if (Result.Length > 4)
                {
                    MessageBox.Show("Число должно состоять из 4 цифр!", "Ошибка");
                    Result = "";
                }
                for (int i = 0; i < Result.Length - 1; ++i)
                {
                    for (int j = i + 1; j < Result.Length; ++j)
                    {
                        if (Result[i] == Result[j])
                        {
                            MessageBox.Show("Цифры не могут повторяться!", "Ошибка");
                            Result = "";
                        }
                    }
                }
            }
        }
    }
}