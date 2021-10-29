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
            List<Prop> NewList = new List<Prop>();
            string menu = "Программа работы с пропусками\n" +
            "=============================\n" +
            "Выберите пункт меню:\n" +
            "1. Добавить пропуск\n" +
            "2. Удалить пропуск\n" +
            "3. Дата последнего выданного пропуска\n" +
            "4. Пропуска за промежуток";

            Console.WriteLine(menu);
            while (true) {
                switch (Console.ReadLine())
                {
                    case "1":

                        Console.WriteLine("");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(menu);
                        Console.ReadKey();
                        break;
                }

            }


        }
    }
}
