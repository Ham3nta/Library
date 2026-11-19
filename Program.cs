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
                        Console.WriteLine($"Поточна кількість записів у Main: {count}");
                        Pause();
                        break;
                    case "3": PrintValues(penalties, count); Pause(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Немає такого пункту."); Pause(); break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== Бібліотека (Робота з масивом пені) ===");
            Console.WriteLine("1 - довідка");
            Console.WriteLine("2 - додати значення пені");
            Console.WriteLine("3 - показати всі записи");
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
    }
}
