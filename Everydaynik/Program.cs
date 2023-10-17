using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everydaynik
{

    internal class Note
    {
        public int day;
        public int num;
        public string name;
        public string description;
        public static List<Note> notes = new List<Note>();
    }


    internal class Menu
    {
        

        static DateTime date1 = DateTime.Now;

        static int action = 0;
        static int notes = 2;
        static void Main()
        {
            Note n1 = new Note()
            {
                day = 17,
                name = "Практическая по шарпу",
                description = "Опять все в последний день делаешь"
            };
            Note.notes.Add(n1);
            Note n2 = new Note()
            {
                day = 18,
                name = "Поездка",
                description = "Съездить на колоборацию Додо и Honkai: Star Rail"
            };
            Note.notes.Add(n2);
            Note n3 = new Note()
            {
                day = 19,
                name = "Пары",
                description = "Это же четверг и всего 2 пары. Изи день"
            };
            Note.notes.Add(n3);
            Note n4 = new Note()
            {
                day = 20,
                name = "Oh shit, here we go again",
                description = "Ну снова четыре пары, пора умират"
            };
            Note.notes.Add(n4);
            Note n5_1 = new Note()
            {
                day = 22,
                name = "УРА ВОСКРЕСЕНЬЕ",
                description = "Нечего радоваться завтра опять 4 пары"
            };
            Note.notes.Add(n5_1);
            Note n5_2 = new Note()
            {
                day = 22,
                name = "Забрать заказ",
                description = "А еще дольше он не мог везти"
            };
            Note.notes.Add(n5_2);
            while (true)
            {
                Menu_data();
                Movie();
                Arrow();
            }
        }


        private static void Arrow()
        {
            Console.Clear();
            Console.SetCursorPosition(0, notes);
            Console.Write("->");
        }


        private static void Menu_data()
        {
            int number = 0;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"Дата:{date1.AddDays(action).Date.ToString("dd.MM.yyyy")}");
            foreach (var element in Note.notes)
            {
                if (element.day == date1.AddDays(action).Day)
                {
                    number++;
                    Console.SetCursorPosition(2, number + 1);
                    element.num = number;
                    Console.Write($"{element.num}.{element.name}\n");
                }
            }

        }
        private static void Mark()
        {
            int number = 0;
            Console.Clear();
            foreach (var element in Note.notes)
            {
                if (element.day == date1.AddDays(action).Day)
                {
                    number++;
                    element.num = number;
                    if (number == notes - 1)
                    {
                        Console.Write($"  {element.name}\n");
                        Console.Write(" " + element.description);
                    }
                }
            }
        }

        private static void Movie()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    action--;
                    break;
                case ConsoleKey.RightArrow:
                    action++;

                    break;
                case ConsoleKey.UpArrow:
                    if (notes < 3)
                    {
                        notes = 2;
                    }
                    else
                    {
                        notes--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (notes > 3)
                    {
                        notes = 4;
                    }
                    else
                    {
                        notes++;
                    }
                    break;
                case ConsoleKey.Enter:
                    Mark();
                    Console.ReadKey();
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("Это конец");
                    System.Environment.Exit(0);
                    break;
            }
        }

        
    }
}
