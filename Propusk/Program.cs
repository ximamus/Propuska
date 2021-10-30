using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace Propusk
{
    class Program
    {
        static void Main(string[] args)
        {             
            Props props = new Props();
            string menu = "Программа работы с пропусками\n" +
            "=============================\n" +
            "Выберите пункт меню:\n" +
            "1. Добавить пропуск\n" +
            "2. Удалить пропуск\n" +
            "3. Дата последнего выданного пропуска\n" +
            "4. Пропуска за промежуток\n" +
            "5. Выход из программы";

            while (true) {
                Console.Clear();
                Console.WriteLine(menu);
                switch (Console.ReadLine())
                {
                    case "1":
                        bool dataSet = false;
                        while (!dataSet)
                        {   
                            
                            Console.WriteLine("Введите ФИО");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите тип пропуска: 1 - обычный, 2 - срочный, 3 - транзит");
                            int type = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Данные верны?\n" +
                                $"Номер пропуска: {props.Propuska.Count + 1}\n" +
                                $"ФИО: {name}\n" +
                                $"Тип пропуска: {type}\n" +
                                $"Дата пропуска: {DateTime.Now}\n" +
                                $"Введите y - да, n - нет");
                            if (Console.ReadLine().ToLower() == "y") {
                                props.Dobav(name, type);                                
                                dataSet = true;                                
                            }                           
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите фамилию человека, чей пропуск нужно удалить");
                        string nameDel = Console.ReadLine();
                        props.DelName(nameDel);
                        break;
                    case "3":
                        Console.WriteLine($"Дата последнего выданного пропуска: {props.LastDate.ToString("d")}\n" +
                            "Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Введите первую дату в формате дд/мм/гггг");
                        DateTime date1 = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Введите вторую дату в формате дд/мм/гггг");
                        DateTime date2 = DateTime.Parse(Console.ReadLine());                        
                        Console.WriteLine($"Количество пропусков, выданных между {date1.ToString("d")} и {date2.ToString("d")}: {props.Amount(date1, date2)}\n" +
                            "Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    case "5":
                        return;
                    default:                        
                        break;
                }
            }
        }
    }
}
