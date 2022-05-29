using System;

namespace TRPO_lab3
{
    class PEditor : AEditor
    {
        string check = "0123456789ABCDEF";

        public override void AddDelim(TANumber a)
        {
            if ((a as TPNumber).IsEmpty()) (a as TPNumber).Value = "0.";
            else if (!(a as TPNumber).Value.Contains('.')) (a as TPNumber).Value += '.';
        }

        public override void Clear(TANumber a)
        {
            (a as TPNumber).Value = "";
        }

        public override void AddDigit(char digit, TANumber a)
        {
            if (!check.Contains(digit)) throw new Exception("Попытка ввода неверного числа");
            else
            {
                if ((a as TPNumber).Value == "0")
                {
                    if (digit == '0') return;
                    else (a as TPNumber).Value = "" + digit;
                }
                else (a as TPNumber).Value += digit;
            }
        }

        public override void Bs(TANumber a)
        {
            if ((a as TPNumber).Value.Length > 0)
                (a as TPNumber).Value = (a as TPNumber).Value.Remove((a as TPNumber).Value.Length - 1, 1);
        }
    }


}
