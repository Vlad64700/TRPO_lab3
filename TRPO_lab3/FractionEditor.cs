using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    class FractionEditor : AEditor
    {
        //Разделитель целой и дробной частей.
        const string delim = ".";

        const string zero = "0";

        const string minus = "-";

        public override void Clear(TANumber number)
        {
            (number as Fraction).Numerator = "";
            (number as Fraction).Denomerator = "";
        }

        public override void AddDigit(char digit, TANumber number)
        {
            //если работаем с числителем
            if ((number as Fraction).IsNumerator)
            {
                //если уже введен ноль
                if ((number as Fraction).Numerator == "0")
                {
                    if (digit == '0') return;
                    (number as Fraction).Numerator = digit.ToString();
                }
                else (number as Fraction).Numerator += digit;
                return;
            }
            //если работаем со знаменателем
            if (digit == '0' && (number as Fraction).Denomerator == "") return;
            if ((number as Fraction).Denomerator == "0")
            {
                if (digit == '0') return;
                else (number as Fraction).Denomerator = digit.ToString();
            }
            else (number as Fraction).Denomerator += digit;
        }

        public override void Bs(TANumber number)
        {
            //если работаем с числителем
            if ((number as Fraction).IsNumerator)
            {
                if ((number as Fraction).Numerator != "")
                    (number as Fraction).Numerator =
                        (number as Fraction).Numerator.Remove((number as Fraction).Numerator.Length - 1, 1);
            }
            else if ((number as Fraction).Denomerator != "")
                (number as Fraction).Denomerator = (number as Fraction)
                    .Denomerator.Remove((number as Fraction).Denomerator.Length - 1, 1);
        }

        public override void AddDelim(TANumber number)
        {
            if ((number as Fraction).IsNumerator)
            {
                if ((number as Fraction).Numerator == "")
                    (number as Fraction).Numerator = "0.";
                else if (!(number as Fraction).Numerator.Contains('.'))
                    (number as Fraction).Numerator += '.';
                return;
            }
            if ((number as Fraction).Denomerator == "")
                (number as Fraction).Denomerator = "0.";
            else if (!(number as Fraction).Denomerator.Contains('.'))
                (number as Fraction).Denomerator += '.';
        }
    }
}
