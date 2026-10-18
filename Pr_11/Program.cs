using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "Практическая работа 11. вариант 6";

            Console.WriteLine("Здравствуй!");
            Console.WriteLine("Программа ищет количество групп (из 0 и 1) длиной ровно в 5 символов.");
            Console.WriteLine("Группы должны быть разделены пробелами.\n");

            while (true)
            {
                try
                {
                    Console.Write("Введите строку (или '0' для выхода): ");
                    string input = Console.ReadLine();

                    if (input != null && input.ToLower() == "0")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Выход из программы. До свидания!");
                        break;
                    }

                    if (String.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("Строка не может быть пустой!");
                    }

                    // Проверка на недопустимые символы (только 0, 1 и пробел)
                    foreach (char c in input)
                    {
                        if (c != '0' && c != '1' && c != ' ')
                        {
                            throw new FormatException("Строка должна состоять только из 0, 1 и пробелов!");
                        }
                    }

                    // Разделяем строку по пробелам, удаляя пустые элементы
                    string[] groups = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int count = 0;

                    // Ищем группы ровно из 5 символов
                    foreach (string group in groups)
                    {
                        if (group.Length == 5)
                        {
                            count++;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nКоличество групп с пятью символами: {count}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка аргумента: {ex.Message}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка формата: {ex.Message}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.ReadKey();
        }
    }
}