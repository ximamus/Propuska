using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Prop
    {
        private int number;
        public string fio;
        private int type;
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

        public void Dobav(string name, int type) {
            Propuska.Add(new Prop(Propuska.Count + 1, name, type, DateTime.Now));
            Console.WriteLine("Пропуск введен\n" +
                "Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        public void DelName(string nameDel) {
            foreach (Prop prop in Propuska) {
                if (prop.fio.Contains(nameDel)) {
                    Console.WriteLine($"Пропуск для {prop.fio} удален");
                    Propuska.Remove(prop);
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    break;
                }
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
