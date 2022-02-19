using System;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace Intersection_of_many
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static int sizeArray = 0; // переменная определяет размер исходных массивов которые заполняются рандомными целыми числами

        public static string IntersectionsSearch()
        {
            /// <summary>
            /// Модуль обработки массива целых чисел
            /// </summary>
            Stopwatch runningTime = Stopwatch.StartNew(); // запуск таймера общего времени работы программы

            int[] array1 = new int[sizeArray];
            int[] array2 = new int[sizeArray];
    
            Random random = new Random();
            for (var i = 0; i < sizeArray; i++) // заполнение массивов размером sizeArray до 100_001
            {
                array1[i] = random.Next(0, 100001);
                array2[i] = random.Next(0, 100001);
            }

            Stopwatch sortingTime = Stopwatch.StartNew(); // запуск таймера времени сортировки

            Array.Sort(array1); // сортировка массивов по возрастанию 
            Array.Sort(array2);

            List<int> arr1 = new List<int>(sizeArray);
            List<int> arr2 = new List<int>(sizeArray);
            List<int> result = new List<int>();

            for (var i = 0; i < sizeArray; i++) // заполнение списков arr1 и arr2 отсортированными по возрастанию элементами соответствующих массивов array1 и array2
            {
                arr1.Add(array1[i]);
                arr2.Add(array2[i]);
            }
            result = arr1.Intersect(arr2).ToList(); // нахождение пересечения двух списков и запись в список result
            Array.Sort(result.ToArray()); // сортировка массива пересечений списков arr1 и arr2

            sortingTime.Stop(); // остановка таймера времени сортировки


            /// <summary>
            /// Модуль расчёта времени работы программы и записи результатов в файл
            /// </summary>

            // создание экзмпляров класса StreamWriter который реализует запись списков в файлы

            StreamWriter st = new StreamWriter(Directory.GetCurrentDirectory() + @"\\Data\intersections.txt");
            StreamWriter st2 = new StreamWriter(Directory.GetCurrentDirectory() + @"\Data\array 1.txt");
            StreamWriter st3 = new StreamWriter(Directory.GetCurrentDirectory() + @"\Data\array 2.txt");
            StreamWriter st4 = new StreamWriter(Directory.GetCurrentDirectory() + @"\Data\runningTime.txt");

            foreach (var k in result) // запись пересечений в файл
            {
                st.WriteLine(k);
            }
            st.Close();

            foreach (var s in arr1) // запись списка arr1
            {
                st2.WriteLine(s);
            }
            st2.Close();

            foreach (var c in arr2) // запись списка arr2
            {
                st3.WriteLine(c);
            }
            st3.Close();

            runningTime.Stop(); // остановка таймера общего времени работы программы

            st4.WriteLine("Поиск пересечения массивов и их сортировка выполнена за " + sortingTime.ElapsedMilliseconds / 1000.0 + " секунд"); // запись времени сортировки
            st4.WriteLine("\nОбщее время работы программы " + runningTime.ElapsedMilliseconds / 1000.0 + " секунд"); // запись общего времени работы программы
            st4.Close();

            // вывод результатов работы метода
            return 
                $"Размер списка 1 [{sizeArray}]" + $"\nРазмер списка 2 [{sizeArray}]" +
                "\n\nВыполнены за " + $"[{sortingTime.ElapsedMilliseconds / 1000.0}]" + " секунд следующие задачи:\n " +
                "\n    1) Сортировка исходных массивов " +
                "\n    2) Поиск пересечений упорядоченных массивов" +
                "\n    3) Сортировка списка содеражащего пересечения" + 
                "\n\nОбщее время работы программы" + $" [{runningTime.ElapsedMilliseconds / 1000.0}] секунд" +
                $"\n\nКоличество пересечений упорядоченных массивов [{result.Count()}]";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            intersectionText.Text = IntersectionsSearch();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            sizeArray = 1000; //default value
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            sizeArray = 10_000;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            sizeArray = 100_000;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            sizeArray = 1_000_000;
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            sizeArray = 10_000_000;
        }
        /*
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StreamReader sr1 = new StreamReader(@"C:\Users\R\source\repos\Intersections 2Arrays\Data\intersections.txt");
            StreamReader sr2 = new StreamReader(@"C:\Users\R\source\repos\Intersections 2Arrays\Data\array 1.txt");
            StreamReader sr3 = new StreamReader(@"C:\Users\R\source\repos\Intersections 2Arrays\Data\array 2.txt");

            Array1Text.Content = sr2.ReadToEnd();
            sr2.Close();
            Array2Text.Content = sr3.ReadToEnd();
            sr3.Close();
            IntersectionsText.Content = sr1.ReadToEnd();
            sr1.Close();
        }*/
    }
}

