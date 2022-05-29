using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    //абстрактный класс для реализации шаблонного типа "число"
    public abstract class TANumber
    {
        public abstract TANumber Add(TANumber b);       // сложить
        public abstract TANumber Sub(TANumber b);       // вычесть
        public abstract TANumber Mul(TANumber b);       // умножить
        public abstract TANumber Div(TANumber b);       // разделить
        public abstract TANumber Sqr();                 // возвести в квадрат
        public abstract TANumber Rev();                 // получить обратное число
        public abstract bool IsEqual(TANumber b);       // определить равенство чисел
        public abstract bool IsEmpty();             // определить равенство нулю
        public abstract override string ToString();     // вернуть значение числа в формате строки
        public abstract TANumber Copy();                // копировать число
        public abstract TANumber Negative();            // число с обратным знаком

        public abstract void ChangeState(int new_state);

        public abstract int GetState();                 //состояние работы с числом
    };
}
