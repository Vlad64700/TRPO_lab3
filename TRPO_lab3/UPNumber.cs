using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    //тип данных самого числа
    class UPNumber
    {
        public int B { get; set; } //основание системы счисления
        public int C { get; set; } // количество знаков после точки
        public double N { get; set; } // само р-ичное число
    }
}
