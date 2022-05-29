using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    //тип данных простой дроби
    class Fraction : TANumber
    {
        //числитель
        public string Numerator { get; set; }

        //знаменатель
        public string Denomerator { get; set; }

        //работаем с числителем?
        public bool IsNumerator { get; set; }

        public Fraction()
        {
            Numerator = "";
            Denomerator = "";
            IsNumerator = true;
        }
        private void check_data(TANumber a, TANumber b)
        {
            if ((a as Fraction).Numerator == "")
                (a as Fraction).Numerator = "1";
            if ((a as Fraction).Denomerator == "")
                (a as Fraction).Denomerator = "1";


            if ((b as Fraction).Numerator == "")
                (b as Fraction).Numerator = "1";
            if ((b as Fraction).Denomerator == "")
                (b as Fraction).Denomerator = "1";
        }

        private void check_data(TANumber a)
        {
            if ((a as Fraction).Numerator == "")
                (a as Fraction).Numerator = "1";
            if ((a as Fraction).Denomerator == "")
                (a as Fraction).Denomerator = "1";
        }
        public Fraction(string numerator, string denomerator)
        {
            if (denomerator == "0")
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю");
            }
            Numerator = numerator;
            Denomerator = denomerator;
            IsNumerator = true;
        }

        // находит НОД, алгоритм Евклида
        int FindGreatestCommonDivider(int a, int b)
        {
            a=Math.Abs(a);
            b=Math.Abs(b); 

            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;
        }

        //переворачиваем дробь
        public override TANumber Rev() {

            check_data(this);
            return new Fraction(Denomerator, Numerator);
        }

        public override TANumber Sqr()
        {
            check_data(this);
            return new Fraction(
            (Convert.ToDouble(Numerator) * Convert.ToDouble(Numerator)).ToString(),
            (Convert.ToDouble(Denomerator) * Convert.ToDouble(Denomerator)).ToString()
            );
        }

        public override TANumber Add(TANumber b)
        {
            check_data(this, b);



            double nextNumerator = Convert.ToDouble(Numerator)
                * Convert.ToDouble((b as Fraction).Denomerator) +
                Convert.ToDouble((b as Fraction).Numerator) * Convert.ToDouble(Denomerator);
            double nextDenomerator = Convert.ToDouble(Denomerator) * Convert.ToDouble((b as Fraction).Denomerator);

            //алгоритм евклида
            int tmp = FindGreatestCommonDivider((int)nextNumerator, (int)nextDenomerator);
            nextNumerator = nextNumerator / tmp;
            nextDenomerator = nextDenomerator / tmp;



            return new Fraction(nextNumerator.ToString(), nextDenomerator.ToString());
        }

        public override TANumber Sub(TANumber b)
        {
            check_data(this, b);

            double nextNumerator = Convert.ToDouble(Numerator)
                * Convert.ToDouble((b as Fraction).Denomerator) -
                 Convert.ToDouble((b as Fraction).Numerator) * Convert.ToDouble(Denomerator);
            double nextDenomerator = Convert.ToDouble(Denomerator) * Convert.ToDouble((b as Fraction).Denomerator);


            //алгоритм евклида
            int tmp = FindGreatestCommonDivider((int)nextNumerator, (int)nextDenomerator);
            nextNumerator = nextNumerator / tmp;
            nextDenomerator = nextDenomerator / tmp;


            return new Fraction(nextNumerator.ToString(), nextDenomerator.ToString());

        }

        public override TANumber Mul(TANumber b)
        {
            check_data(this, b);

            double nextNumerator = Convert.ToDouble(Numerator) * Convert.ToDouble((b as Fraction).Numerator);
            double nextDenomerator = Convert.ToDouble(Denomerator) * Convert.ToDouble((b as Fraction).Denomerator);

            //алгоритм евклида
            int tmp = FindGreatestCommonDivider((int)nextNumerator, (int)nextDenomerator);
            nextNumerator = nextNumerator / tmp;
            nextDenomerator = nextDenomerator / tmp;



            return new Fraction(nextNumerator.ToString(), nextDenomerator.ToString());

        }

        public override TANumber Div(TANumber b)
        {
            check_data(this, b);

            double nextNumerator = Convert.ToDouble(Numerator) * Convert.ToDouble((b as Fraction).Denomerator);
            double nextDenomerator = Convert.ToDouble(Denomerator) * Convert.ToDouble((b as Fraction).Numerator);

            //алгоритм евклида
            int tmp = FindGreatestCommonDivider((int)nextNumerator, (int)nextDenomerator);
            nextNumerator = nextNumerator / tmp;
            nextDenomerator = nextDenomerator / tmp;



            return new Fraction(nextNumerator.ToString(), nextDenomerator.ToString());
        }

        public override TANumber Negative() => new Fraction("-" + Numerator, Denomerator);


        public override TANumber Copy() => new Fraction(Numerator, Denomerator);

        public override bool IsEqual(TANumber b) => Numerator == (b as Fraction).Numerator &&
            Denomerator == (b as Fraction).Denomerator;

        public override bool IsEmpty() => Numerator == "" && Denomerator == "";

        public override string ToString() 
        {
            string res = "";

            if (Numerator != "" || Denomerator != "")
            {
                res += "( ";

                res += (Numerator == "" ? (IsNumerator ? "" : "1") : Numerator);
                res += " / ";
                if (Numerator == "0") res += "0";
                else
                {
                    res += (Denomerator == "" ? "1" : Denomerator);
                }
                res += " )";
            }

            return res;
        } 

        public override int GetState()
        {
            if (IsNumerator) return -1;
            else return -2;
        }

        // Изменение части, с которой работем - числитель или знаменатель
        public override void ChangeState(int new_state)
        {
            if (new_state == -1) IsNumerator = true;
            else if (new_state == -2) IsNumerator = false;
        }
    }
}
