using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    class ComplexEditor : AEditor
    {
        public override void AddDelim(TANumber number)
        {
            //если работаем с реальной частью числа
            if ((number as Complex).IsRe)
            {
                if ((number as Complex).Re == "")
                    (number as Complex).Re = "0.";
                else if (!(number as Complex).Re.Contains('.'))
                    (number as Complex).Re += '.';
                return;
            }
            
            //если работаем с мнимой частью числа
            if ((number as Complex).Im == "")
                (number as Complex).Im = "0.";
            else if (!(number as Complex).Im.Contains('.')) (number as Complex).Im += '.';
        }

        public override void Clear(TANumber number)
        {
            (number as Complex).Re = "";
            (number as Complex).Im = "";
        }

        public override void AddDigit(char digit, TANumber number)
        {
            //если работаем с реальной частью числа
            if ((number as Complex).IsRe)
            {
                if ((number as Complex).Re == "0")
                {
                    if (digit == '0') return;
                    else (number as Complex).Re = digit.ToString();
                }
                else (number as Complex).Re += digit;
            }
            //если работаем с мнимой частью числа
            else
            {
                if ((number as Complex).Im == "0")
                {
                    if (digit == '0') return;
                    else (number as Complex).Im = digit.ToString();
                }
                else (number as Complex).Im += digit;
            }
        }

        public override void Bs(TANumber number)
        {
            if ((number as Complex).IsRe)
            {
                if ((number as Complex).Re != "")
                    (number as Complex).Re = (number as Complex).
                        Re.Remove((number as Complex).Re.Length - 1, 1);
            }
            else if ((number as Complex).Im != "")
                (number as Complex).Im = (number as Complex).Im.
                    Remove((number as Complex).Im.Length - 1, 1);
        }
    }
}
