using System;
using System.Collections.Generic;

namespace Кадровый_учет_продвинутый
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddEmployees = "1";
            const string CommandShowAllDossier = "2";
            const string CommandDeliteDossier = "3";
            const string CommandExit = "4";

            List<string> names = new List<string>(0);
            List<string> position = new List<string>(0);
            string userInput;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{CommandAddEmployees}: добавить досье");
                Console.WriteLine($"{CommandShowAllDossier}: вывести все досье");
                Console.WriteLine($"{CommandDeliteDossier}: удалить досье");
                Console.WriteLine($"{CommandExit}: выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddEmployees:
                        AddDossier(names, position);
                        break;

                    case CommandShowAllDossier:
                        ShowAllEmployees(names, position);
                        break;

                    case CommandDeliteDossier:
                        DeliteEmployee(names, position);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("неверный ввод");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossier(List<string> names , List<string> position)
        {
            Console.WriteLine("введите Ф.И.О.");
            string input = Console.ReadLine();

            names.Add(input);

            Console.WriteLine("введите должность");
            input = Console.ReadLine();

            position.Add(input);
        }

        static void ShowAllEmployees(List<string> names, List<string> position)
        {
            Console.WriteLine("список сотрудников:");

            if (names.Count > 0)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    Console.Write($"{i + 1}: {names[i]} - {position[i]}");
                    Console.WriteLine();
                }
            }
        }

        static void DeliteEmployee(List<string> names, List<string> position)
        {
            ShowAllEmployees(names, position);

            Console.Write("удаление сотрудника из базы данных. выберете номер:");
            string input = Console.ReadLine();
            int index;

            if (int.TryParse(input, out index))
            {
                index -= 1;

                if (index >= 0 && index < names.Count)
                {
                    names.RemoveAt(index);
                    position.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("неправильный ввод");
                }
            }
        }
    }
}
