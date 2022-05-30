using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    //тип данных комплексного числа
    class Complex : TANumber
    {
        public string Re { get; set; }
        public string Im { get; set; }

        //работаем с действительной частью?
        public bool IsRe { get; set; }

        public Complex()
        {
            Re = "";
            Im = "";
            IsRe = true;
        }

        public Complex(string re, string im, bool IsRe=true)
        {
            Re = re;
            Im = im;
            this.IsRe = IsRe;
        }

        private void check_data(TANumber a)
        {
            if ((a as Complex).Re == "")
                (a as Complex).Re = "0";
            if ((a as Complex).Im == "")
                (a as Complex).Im = "0";
        }

        // (1 + i)^(-1) = 1 / (1 + i)
        public override TANumber Rev()
        {
            check_data(this);
            return (new Complex("1", "0")).Div(this);
        }
            

        public override TANumber Sqr()
        {
            check_data(this);
            return Mul(new Complex(Re, Im));
        }
            

        public override TANumber Add(TANumber b)
        {
            check_data(this);
            check_data(b);

            double nextRe = Convert.ToDouble(Re) + Convert.ToDouble((b as Complex).Re);
            double nextIm = Convert.ToDouble(Im) + Convert.ToDouble((b as Complex).Im);
            return new Complex(nextRe.ToString(), nextIm.ToString());
        }

        public override TANumber Sub(TANumber b)
        {
            check_data(this);
            check_data(b);

            double nextRe = Convert.ToDouble(Re) - Convert.ToDouble((b as Complex).Re);
            double nextIm = Convert.ToDouble(Im) - Convert.ToDouble((b as Complex).Im);
            return new Complex(nextRe.ToString(), nextIm.ToString());

        }

        //формулы с методички по алгему для умножения, деления комплексных чисел.
        public override TANumber Mul(TANumber b)
        {
            check_data(this);
            check_data(b);

            double nextRe = Convert.ToDouble(Re) * Convert.ToDouble((b as Complex).Re)
                - Convert.ToDouble(Im) * Convert.ToDouble((b as Complex).Im);
            double nextIm = Convert.ToDouble(Re) * Convert.ToDouble((b as Complex).Im)
                + Convert.ToDouble((b as Complex).Re) * Convert.ToDouble(Im);
            return new Complex(nextRe.ToString(), nextIm.ToString());
        }

        public override TANumber Div(TANumber b)
        {
            check_data(this);
            check_data(b);

            double tempDenomerator = (Convert.ToDouble((b as Complex).Re) * Convert.ToDouble((b as Complex).Re) +
                Convert.ToDouble((b as Complex).Im) * Convert.ToDouble((b as Complex).Im));
            double nextRe = (Convert.ToDouble(Re) * Convert.ToDouble((b as Complex).Re)
                + Convert.ToDouble(Im) * Convert.ToDouble((b as Complex).Im)) / tempDenomerator;
            double nextIm = (Convert.ToDouble((b as Complex).Re) * Convert.ToDouble(Im) -
                Convert.ToDouble(Re) * Convert.ToDouble((b as Complex).Im)) / tempDenomerator;
            nextRe = Math.Round(nextRe, 5); //округляем
            nextIm = Math.Round(nextIm, 5); //округляем

            return new Complex(nextRe.ToString(), nextIm.ToString());
        }

        public override TANumber Negative()
        { 
            check_data(this);
            if (IsRe)
            {
                if (Re[0] == '-')
                    return new Complex(Re.Substring(1), Im);
                else
                    return new Complex("-" + Re, Im);
            }
            else
            {
                if (Im[0] == '-')
                    return new Complex(Re,Im.Substring(1), false);
                else
                    return new Complex(Re, "-"+Im, false);
            }

           
        }

        

        public override TANumber Copy() => new Complex(Re, Im);

        public override bool IsEqual(TANumber b) => Re == (b as Complex).Re &&
            Im == (b as Complex).Im;

        public override bool IsEmpty() => Re == "" && Im == "";

        public override string ToString()
        {
            string res = "";
            if (Re != "" || Im != "")
            {
                res += (Re == "" ? "0" : Re);
                res += Im == "" ? "+ i (0)" : "+ i (" + Im + ")";
            }

            return res;
        }

        // Вернуть то, с чем работаем - числитель или знаменатель.
        public override int GetState()
        {
            return IsRe ? -1 : -2;
        }

        public override void ChangeState(int new_state)
        {
            if (new_state == -1) IsRe = true;
            else if (new_state == -2) IsRe = false;
            else throw new Exception("Неверное состояние");
        }
    }
}
