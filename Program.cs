using System;
using System.Text;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool running = true;

            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": ShowAbout(); Pause(); break;
                    case "2": HandlePenaltyTable(); Pause(); break;
                    case "3": ShowIssuanceTable(); Pause(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Немає такого пункту."); Pause(); break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== Бібліотека ===");
            Console.WriteLine("1 - довідка");
            Console.WriteLine("2 - розрахунок пені");
            Console.WriteLine("3 - таблиця видачі");
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
            Console.WriteLine("Поля:");
            Console.WriteLine("id - int");
            Console.WriteLine("title - string");
            Console.WriteLine("author - string");
            Console.WriteLine("publishYear - int");
            Console.WriteLine("genre - string");
            Console.WriteLine("copies - int");
            Console.WriteLine("isIssued - bool");
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

        static void HandlePenaltyTable()
        {
            double start = ReadDouble("Початкова кількість днів (1-100): ", 1, 100);
            double end = ReadDouble("Кінцева кількість днів (1-365): ", start, 365);
            double step = ReadDouble("Крок (0.1-10): ", 0.1, 10);
            PrintPenaltyTable(start, end, step);
        }

        static double CalculatePenalty(double days, double rate)
        {
            return days * rate;
        }

        static void PrintPenaltyTable(double start, double end, double step)
        {
            Console.WriteLine("\n     Дні |    Пеня");
            for (double days = start; days <= end + 1e-9; days += step)
            {
                double penalty = CalculatePenalty(days, 5.0);
                Console.WriteLine($"{days,8:F2} | {penalty,7:F2}");
            }
        }

        static void ShowIssuanceTable()
        {
            int rows = ReadInt("Кількість жанрів (1-20): ", 1, 20);
            int cols = ReadInt("Кількість днів (1-31): ", 1, 31);

            int[] colSums = new int[cols];
            int totalSum = 0;

            Console.Write($"\n{"Жанр",-10}");
            for (int c = 1; c <= cols; c++)
            {
                Console.Write($"{$"День {c}",8}");
            }
            Console.WriteLine($"{"Разом",8}");

            for (int r = 1; r <= rows; r++)
            {
                int rowSum = 0;
                Console.Write($"{$"Жанр {r}",-10}");

                for (int c = 1; c <= cols; c++)
                {
                    int books = r + c;
                    Console.Write($"{books,8}");
                    rowSum += books;
                    colSums[c - 1] += books;
                }

                Console.WriteLine($"{rowSum,8}");
                totalSum += rowSum;
            }

            Console.Write($"{"Всього",-10}");
            for (int c = 0; c < cols; c++)
            {
                Console.Write($"{colSums[c],8}");
            }
            Console.WriteLine($"{totalSum,8}");
        }
    }
}
