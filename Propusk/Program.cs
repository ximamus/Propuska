using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace Propusk
{
    class Program {
        static void Main(string[] args) {             
            Props props = new Props();
            string menu = "Программа работы с пропусками\n" +
            "=============================\n" +
            "Выберите пункт меню:\n" +
            "1. Добавить пропуск\n" +
            "2. Удалить пропуск\n" +
            "3. Дата последнего выданного пропуска\n" +
            "4. Пропуска за промежуток\n" +
            "5. Выход из программы";
            int type = 0;            

            while (true) {
                Console.Clear();
                Console.WriteLine(menu);
                switch (Console.ReadLine())
                {
                    case "1":
                        bool dataSet = false;
                        while (!dataSet) {                               
                            Console.WriteLine("Введите ФИО");
                            string name = Console.ReadLine();
                            bool propType = false;                            
                            while (!propType) {
                                Console.WriteLine("Введите тип пропуска: 1 - обычный, 2 - срочный, 3 - транзит");
                                type = Convert.ToInt32(Console.ReadLine());
                                if (type == 1 || type == 2 || type == 3) {
                                    propType = true;
                                }
                            }
                            int number = props.CheckNumber();
                            Console.WriteLine("Данные верны?\n" +
                                $"Номер пропуска: {number += 1}\n" +
                                $"ФИО: {name}\n" +
                                $"Тип пропуска: {type}\n" +
                                $"Дата пропуска: {DateTime.Now}\n" +
                                $"Введите y - да, n - нет");
                            if (Console.ReadLine().ToLower() == "y") {
                                props.Dobav(number, name, type);                                
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
                        try {
                            Console.WriteLine($"Дата последнего выданного пропуска: {props.LastDate.ToString("d")}\n" +
                            "Нажмите любую клавишу для продолжения");
                        }
                        catch {
                            Console.WriteLine("Список пропусков пустой\n" +
                                "Нажмите любую клавишу для продолжения");
                        }                        
                        Console.ReadKey();
                        break;
                    case "4":
                        DateTime date1, date2;
                        date1 = date2 = new DateTime();
                        bool dateSet = false;                        
                        while (!dateSet) {
                            try {
                                Console.WriteLine("Введите первую дату в формате дд/мм/гггг");
                                date1 = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Введите вторую дату в формате дд/мм/гггг");
                                date2 = DateTime.Parse(Console.ReadLine());
                                if (date2 < date1) {
                                    Console.WriteLine("Последняя дата меньше первой\n" +
                                        "Нажмите любую клавишу для продолжения");
                                    Console.ReadKey();
                                }
                                else {
                                    dateSet = true;
                                }
                            }
                            catch {
                                Console.WriteLine("Формат даты неверный, введите даты заново\n" +
                                    "==========================================");
                            }
                        }                                  
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
