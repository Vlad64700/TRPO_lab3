using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    class TPNumber : TANumber
    {
        // Свойства класса 

        public string Value { get; set; }

        public int Notation { get; set; }

        public TPNumber()
        {
            Value = "";
            Notation = 10;
        }

        public TPNumber(string number, int notation)
        {
            Value = number;
            Notation = notation;
        }

        // Возведение числа в cтепень

        public override TANumber Sqr()
        {
            double first = Conver_p_10.dval(this.Value, this.Notation);
            string result = Conver_10_p.Do(Math.Pow(first, 2), this.Notation);
            return (new TPNumber(result, this.Notation));
        }

        public override TANumber Rev()
        {
            double first = Conver_p_10.dval(this.Value, this.Notation);
            string result = Conver_10_p.Do(1/first, this.Notation);
            return (new TPNumber(result, this.Notation));
        }

        public override TANumber Negative()
        {
            double first = Conver_p_10.dval(this.Value, this.Notation);
            string result = Conver_10_p.Do(-first, this.Notation);
            return (new TPNumber(result, this.Notation));
        }

        public override bool IsEqual(TANumber a)
        {
            double first = Conver_p_10.dval(this.Value, this.Notation);
            string result = Conver_10_p.Do(-first, this.Notation);
            return true;
        }

        public override TANumber Copy()
        {
            return new TPNumber();
        }

        public override bool IsEmpty()
        {
            return this.Value == "" ? true : false;
        }

        // Изменение системы счисления на указанную
        public override void ChangeState(int new_state)
        {
            if (new_state < 2 || new_state > 16)
                throw new Exception("Неверная система счисления");

            if (!IsEmpty())
            {
                double tmp = Conver_p_10.dval(Value, Notation);
                Value = Conver_10_p.Do(tmp, new_state);
            }
            this.Notation = new_state;
        }

        public void ChangeSign()
        {
            if (this.Value == "") return;
            if (this.Value[0] == '-') this.Value = this.Value.Remove(0, 1);
            else this.Value = '-' + this.Value;
        }

        public override TANumber Add(TANumber b)
        {
            Validtation(this);
            Validtation(b as TPNumber);

            double first = Conver_p_10.dval(Value, Notation);
            double second = Conver_p_10.dval((b as TPNumber).Value, (b as TPNumber).Notation);
            string result = Conver_10_p.Do((first + second), Notation);
            return (new TPNumber(result, Notation));
        }

        public override TANumber Mul(TANumber b)
        {
            Validtation(this);
            Validtation(b as TPNumber);

            double first = Conver_p_10.dval(Value, Notation);
            double second = Conver_p_10.dval((b as TPNumber).Value, (b as TPNumber).Notation);
            string result = Conver_10_p.Do((first * second), Notation);
            return (new TPNumber(result, Notation));
        }

        public override TANumber Sub(TANumber b)
        {
            Validtation(this);
            Validtation(b as TPNumber);

            double first = Conver_p_10.dval(Value, Notation);
            double second = Conver_p_10.dval((b as TPNumber).Value, (b as TPNumber).Notation);
            string result = Conver_10_p.Do((first - second), Notation);
            return (new TPNumber(result, Notation));
        }

        public override TANumber Div(TANumber b)
        {
            Validtation(this);
            Validtation(b as TPNumber);

            double first = Conver_p_10.dval(Value, Notation);
            double second = Conver_p_10.dval((b as TPNumber).Value, (b as TPNumber).Notation);
            string result = Conver_10_p.Do((first / second), Notation);
            return (new TPNumber(result, Notation));
        }


        public override string ToString()
        {
            return this.Value;
        }

        // Вернуть систему счисления.
        public override int GetState()
        {
            return this.Notation;
        }

        private void Validtation(TPNumber a)
        {
            if (a.Value == "") a.Value = "0";
            if (a.Value[0] == '.') a.Value = "0.0";
            if (a.Value[a.Value.Length - 1] == '.') a.Value += "0";
        }
    }


}
