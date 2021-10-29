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
        private string fio;
        private int type;
        private DateTime data;


        public Prop(int number, string fio, int type, DateTime data) {
            this.number = number;
            this.fio = fio;
            this.type = type;
            this.data = data;
        }

        
    }
}
