using System;
using System.Text;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double[] penalties = new double[100];
            int count = 0;
            bool running = true;

            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": ShowAbout(); Pause(); break;
                    case "2":
                        double val = ReadDouble("Введіть суму пені (0.5 - 1000): ", 0.5, 1000);
                        AddValue(penalties, ref count, val);
                        Console.WriteLine($"Додано. Всього записів: {count}");
                        Pause();
                        break;
                    case "3":
                        int num = ReadInt("Введіть номер запису для видалення: ", 1, 100);
                        RemoveAt(penalties, ref count, num - 1);
                        Pause();
                        break;
                    case "4": PrintValues(penalties, count); Pause(); break;
                    case "5": ShowStatistics(penalties, count); Pause(); break;
                    case "6": RunReferenceExperiment(); Pause(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Немає такого пункту."); Pause(); break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== Бібліотека (Робота з масивом пені) ===");
            Console.WriteLine("1 - довідка");
            Console.WriteLine("2 - додати значення");
            Console.WriteLine("3 - видалити за номером");
            Console.WriteLine("4 - показати всі записи");
            Console.WriteLine("5 - показати статистику");
            Console.WriteLine("6 - дослід: значимий та посилальний типи");
            Console.WriteLine("0 - вихід");
            Console.Write("Вибір: ");
        }

        static void Pause()
        {
            Console.WriteLine("\nНатисніть клавішу...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void ShowAbout()
        {
            Console.WriteLine("Тема: Бібліотека");
            Console.WriteLine("Сутність: Книга");
            Console.WriteLine("Поля: id (int), title (string), author (string), publishYear (int), genre (string), copies (int), isIssued (bool)");
        }

        static double ReadDouble(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (!double.TryParse(Console.ReadLine(), out double value))
                {
                    Console.WriteLine("Помилка: введіть число.");
                    continue;
                }
                if (value < min || value > max)
                {
                    Console.WriteLine($"Помилка: число має бути від {min} до {max}.");
                    continue;
                }
                return value;
            }
        }

        static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out int value))
                {
                    Console.WriteLine("Помилка: введіть ціле число.");
                    continue;
                }
                if (value < min || value > max)
                {
                    Console.WriteLine($"Помилка: число має бути від {min} до {max}.");
                    continue;
                }
                return value;
            }
        }

        static void AddValue(double[] values, ref int count, double newValue)
        {
            if (count >= values.Length)
            {
                Console.WriteLine("Місця в масиві більше немає.");
                return;
            }
            values[count] = newValue;
            count++;
        }

        static void RemoveAt(double[] values, ref int count, int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Помилка: запису з таким номером не існує.");
                return;
            }

            for (int i = index; i < count - 1; i++)
            {
                values[i] = values[i + 1];
            }
            count--;
            Console.WriteLine($"Запис №{index + 1} видалено. Залишилося записів: {count}");
        }

        static void PrintValues(double[] values, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("Масив порожній.");
                return;
            }

            Console.WriteLine(" № | Сума пені");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1,2} | {values[i],9:F2}");
            }
        }

        static void FindMax(double[] values, int count, out double maxValue, out int maxIndex)
        {
            if (count == 0)
            {
                maxValue = 0;
                maxIndex = -1;
                return;
            }

            maxValue = values[0];
            maxIndex = 0;
            for (int i = 1; i < count; i++)
            {
                if (values[i] > maxValue)
                {
                    maxValue = values[i];
                    maxIndex = i;
                }
            }
        }

        static void ShowStatistics(double[] values, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("Немає даних для статистики (масив порожній).");
                return;
            }

            FindMax(values, count, out double maxVal, out int maxIdx);
            Console.WriteLine($"Кількість записів: {count}");
            Console.WriteLine($"Найбільша пеня: {maxVal:F2} (запис №{maxIdx + 1})");
        }

        static void TryChangeInt(int number)
        {
            number = 999;
        }

        static void ChangeFirstElement(double[] arr)
        {
            arr[0] = 999.0;
        }

        static void RunReferenceExperiment()
        {
            int x = 10;
            Console.WriteLine($"До виклику TryChangeInt: x = {x}");
            TryChangeInt(x);
            Console.WriteLine($"Після виклику TryChangeInt: x = {x} (не змінився, бо передана копія)");

            double[] demoArr = { 10.0, 20.0, 30.0 };
            Console.WriteLine($"\nДо виклику ChangeFirstElement: demoArr[0] = {demoArr[0]}");
            ChangeFirstElement(demoArr);
            Console.WriteLine($"Після виклику ChangeFirstElement: demoArr[0] = {demoArr[0]} (змінився, бо передано посилання)");
        }
    }
}
