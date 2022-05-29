using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    public abstract class AEditor
    {
        //добавить символ в число
        public abstract void AddDigit(char ch, TANumber number);
        //удалить символ справа
        public abstract void Bs(TANumber number);
        //очистить число
        public abstract void Clear(TANumber number);

        //добавить разделитель (точку)
        public abstract void AddDelim(TANumber number);

        // вернуть значение числа в формате строки
        //public abstract override string ToString();    

    }
}
