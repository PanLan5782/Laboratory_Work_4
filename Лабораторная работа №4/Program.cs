 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int[] M = null;
            string userCommand = null;
            do
            {
                Console.WriteLine("1.Создать массив");
                Console.WriteLine("2.Удалить все нечетные элементы массива");
                Console.WriteLine("3.Добавить К элементов в конец массива");
                Console.WriteLine("4.Найти элементы с заданным значением");
                Console.WriteLine("5.Найти элементы с заданным значением в отсоритрованном массиве");
                Console.WriteLine("6.Отсортировать массив методом простого обмена");
                Console.WriteLine("7.Распечатать массив");
                Console.WriteLine("8.Выход");

                Console.Write(">");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "1":
                        CreateArray(ref M);
                        break;
                    case "2":
                        DeleteOddItems(ref M);
                        break;
                    case "3":
                        AddItems(ref M);
                        break;
                    case "4":
                        Find(ref M);
                        break;
                    case "5":
                        SortFind(ref M);
                        break;
                    case "6":
                        Sort(ref M);
                        break;
                    case "7":
                        Print(M);
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "8");
        }

        private static void AddItems(ref int[] M)
        {
            int k;
            Console.Write("Введите колличество добавляемых элементов:");
            k = int.Parse(Console.ReadLine());
            int[] T = new int[M.Length + k];


            for (int i = M.Length; i < T.Length; i++)
                T[i] = rnd.Next(-100, 100);

            M.CopyTo(T, 0);

            M = T;
            //int l = 0, m = M.Length - 1, tmp;

            //while (l != m)
            //    if (M[l] < 0)
            //    {
            //        tmp = M[m];
            //        M[m] = M[l];
            //        M[l] = tmp;
            //        m--;
            //    }
            //    else
            //        l++;
        }

        /// <summary>
        /// Удаление нечетных элементов
        /// </summary>
        /// <param name="M">Массив целых чисел</param>
        private static void DeleteOddItems(ref int[] M)
        {
            if (M == null)
            {
                Console.WriteLine("Массив пустой");
                return;
            }
            int count = 0; //счетчик четных элементов

            for (int i = 0; i < M.Length; i++)
            {
                if (M[i] % 2 == 0)
                    count++;
            }
            int[] T = new int[count];

            int j = 0;
            for (int i = 0; i < M.Length; i++)
                if (M[i] % 2 == 0)
                {
                    T[j] = M[i];
                    j++;
                }
            M = T;
        }

        private static void CreateArray(ref int[] M)
        {
            int n = 0;
            do
            {
                n = ParseInteger("Введите колличество элементов массива:");
                if (n <= 0)
                    Console.WriteLine("Значение \"{0}\" должно быть положительным. Повторите, пожалуйста, ввод.", n);

            } while (n<=0);

            M = new int[n];
            for (int i = 0; i < n; i++)
                M[i] = rnd.Next(-100, 100);
        }


        /// <summary>
        /// Ввод целого числа с клавиатуры с контролем.
        /// </summary>
        /// <param name="s">Введенная строка</param>
        /// <returns>Целое число</returns>
        static int ParseInteger(string prompt)
        {
            int v = 0;
            bool ok = false;
            do {
                Console.Write(prompt);
                string s = Console.ReadLine();
                ok = int.TryParse(s, out v);
                if (!ok)
                    Console.WriteLine("Значение \"{0}\" не является целым числом. Повторите, пожалуйста, ввод.", s);
            } while (!ok);

            return v;
        }

        static void Print(int[] A)
        {
            if (A == null)
            {
                Console.WriteLine("Массив пустой");
                return;
            }

            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("Item[{1}]={0} ", A[i], i);
            }
            Console.WriteLine();

        }

        static void Sort(ref int[] M)
        {
            for (int i = 1; i <= M.Length; i++)
                for (int j = M.Length - 1; j >= i; j--)
                    if (M[j] < M[j - 1])
                    {
                        int temp = M[j];
                        M[j] = M[j - 1];
                        M[j - 1] = temp;
                    }

        }
        static void SortFind(ref int[] M)
        {
            Console.WriteLine("Введите число для поиска");
            int numberForFind = Convert.ToInt32(Console.ReadLine());
            int left = 0, right = M.Length - 1, sred;
            do
            {
                sred = (left + right) / 2;//средний элемент
                if (M [sred] < numberForFind)
                    left = sred + 1;//перенести левую границу
                else
                    right = sred;//перенести правую границу
            } while (left != right);
            if (M [left] == numberForFind)
                Console.WriteLine("Номер Элемента {0} равен {1}", numberForFind, left + 1);
            else
                Console.WriteLine("Элемент не найден");
        }
        static void Find (ref int[] M)
        {

            int numberForFind;
            int i = -1;
                Console.WriteLine("Введите число для поиска");
            numberForFind = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < M.Length && M[i] != numberForFind; i++);

            if (i == M.Length)
                Console.WriteLine("Элемент не найден");
            else
                Console.WriteLine("Номер Элемента {0} равен {1}", numberForFind, i+1);

        }
    }
 }
    
