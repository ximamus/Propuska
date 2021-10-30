using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Prop
    {
        public int number;
        public string fio;
        public int type;
        public DateTime data;

        public Prop(int number, string fio, int type, DateTime data)
        {
            this.number = number;
            this.fio = fio;
            this.type = type;
            this.data = data;
        }
    }

    public class Props
    {
        public List<Prop> Propuska = new List<Prop>();

        public int CheckNumber() {
            int number = 0;
            foreach (Prop prop in Propuska) {
                if (prop.number > number) {
                    number = prop.number;
                }
            }
            return number;
        }

        public void Dobav(int number, string name, int type) {
            Propuska.Add(new Prop(number, name, type, DateTime.Now));
            Console.WriteLine("Пропуск введен\n" +
                "Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        public void DelName(string nameDel) {
            bool found = false;
            foreach (Prop prop in Propuska) {
                if (prop.fio.Contains(nameDel)) {
                    found = true;
                    Console.WriteLine($"Пропуск для {prop.fio} удален");
                    Propuska.Remove(prop);
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    break;
                }
            }
            if (!found) {
                Console.WriteLine($"Фамилия {nameDel} не найдена\n" +
                    "Нажмите любую клавишу для продолжения");
                Console.ReadKey();
            }
        }

        public DateTime LastDate {
            get {                
                    Prop lastData = Propuska.Last();
                    return lastData.data;                
            }
        }

        public int Amount(DateTime date1, DateTime date2) {
            int amount = 0;
            foreach (Prop prop in Propuska) {
                if (DateTime.Compare(prop.data, date1) > 0 && DateTime.Compare(prop.data, date2) < 0) {
                    amount++;
                }
            }            
            return amount;
        }        
    }
}
