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
                Console.WriteLine("=== Бібліотека ===");
                Console.WriteLine("1 - довідка");
                Console.WriteLine("2 - розрахунок пені");
                Console.WriteLine("3 - таблиця видачі");
                Console.WriteLine("0 - вихід");
                Console.Write("Вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAbout();
                        Pause();
                        break;
                    case "2":
                        ShowPenaltyTable();
                        Pause();
                        break;
                    case "3":
                        Console.WriteLine("Поки не зроблено.");
                        Pause();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Немає такого пункту.");
                        Pause();
                        break;
                }
            }
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

        static void ShowPenaltyTable()
        {
            Console.WriteLine("     Дні |    Пеня");
            for (double days = 1.0; days <= 5.0 + 1e-9; days += 0.5)
            {
                double penalty = days * 5.0;
                Console.WriteLine($"{days,8:F2} | {penalty,7:F2}");
            }
        }
    }
}
