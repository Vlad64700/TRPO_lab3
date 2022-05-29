 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    class TProc
    {

        private TANumber leftOperand;

        private TANumber rightOperand;

        private char Operator;

        // Операнд, который хранится в буфере
        private TANumber bufferNumber;

        // Операция, которая хранится в буфере
        private char bufferOperation;

        // Операнд, который хранится в памяти
        private TANumber savedNumber;

        // Флаг, показывающий, с каким операндом работаем: 
        private bool isLeftOperand;

        private AEditor editor;


        // Свойство, описывающее состояние приложения.
        // Для п-ичного числа - это система счисления,
        // для дроби - работа с числителемили с знаменателем,
        // для комплексного числа - работа с Re.
        public int State
        {
            get
            {
                return leftOperand.GetState();
            }
            set
            {
                ChangeState(value);
            }
        }

        // Свойство, которое строит отображаемый на экране текст
        public string Text
        {
            get
            {
                string res = string.Empty;

                res += leftOperand.ToString();
                if (!isLeftOperand && !NoOperator()) // Если работаем не с левым операндом и оператор установлен (!= '0').
                {
                    res += " " + Operator + " ";
                    res += rightOperand;
                }

                return string.IsNullOrEmpty(res) ? "0" : res; // Если пустое значение, то вернуть все равно "0".
            }
        }

        public TANumber CurrentNumber
        {
            get
            {
                return isLeftOperand ? leftOperand : rightOperand;
            }
            set
            {
                if (isLeftOperand) leftOperand = value;
                else rightOperand = value;
            }
        }

        public enum EditorType
        {
            pAdic = 1,
            complex = 2,
            fraction = 3
        }


        // Конструктор класса
        public TProc(int numberType)
        {
            switch (numberType)
            {
                case (int)EditorType.pAdic:
                    {
                        leftOperand = new TPNumber();
                        rightOperand = new TPNumber();
                        bufferNumber = new TPNumber();
                        savedNumber = new TPNumber();
                        editor = new PEditor();
                        break;
                    }

                case (int)EditorType.complex:
                    {
                        leftOperand = new Complex();
                        rightOperand = new Complex();
                        bufferNumber = new Complex();
                        savedNumber = new Complex();
                        editor = new ComplexEditor();
                        break;
                    }
                case (int)EditorType.fraction:
                    {
                        leftOperand = new Fraction();
                        rightOperand = new Fraction();
                        bufferNumber = new Fraction();
                        savedNumber = new Fraction();
                        editor = new FractionEditor();
                        break;
                    }
            }

            //default values
            Operator = '0';
            isLeftOperand = true;
            bufferOperation = '0';
        }

        // Метод, изменяющий State всех операндов.
        public void ChangeState(int new_state)
        {
            leftOperand.ChangeState(new_state);
            rightOperand.ChangeState(new_state);
            bufferNumber.ChangeState(new_state);
            savedNumber.ChangeState(new_state);
        }

        public void AddDigit(char digit)
        {
            editor.AddDigit(digit, CurrentNumber);
        }
        public void AddDelim()
        {
            editor.AddDelim(CurrentNumber);
        }

        public void SetOperator(char op)
        {
            if (isLeftOperand || rightOperand.IsEmpty()) // Если работаем с первым числом или ввели только первое число и операцию 
            {
                isLeftOperand = false;
                Operator = op;             // (но не ввели второе), то только изменим операцию.
            }
            else
            {
                PerformOperationOnTwoOperands();        // Иначе посчитаем, что у нас есть и добавим новую операцию.
                isLeftOperand = false;
                Operator = op;
            }
        }

        public void Bs()
        {
            editor.Bs(CurrentNumber);
        }
        public void ChangeSign()
        {
            //(editor as PEditor).ChangeSign(CurrentNumber as TPNumber);
        }

        private void ResetOperator()
        {
            Operator = '0';
        }

        public void ResetCurNum()
        {
            editor.Clear(CurrentNumber);
        }


        public void Reset()
        {
            editor.Clear(leftOperand);
            editor.Clear(rightOperand);
            isLeftOperand = true;
            ResetOperator();
        }

        private bool NoOperator()
        {
            return Operator == '0';
        }

        //ПОМЕНЯТЬ !!!!!!!!!!!!!!!!!
        public void DoUnaryOperation(int op)
        {
            switch (op)
            {
                case 22: // x^2
                    CurrentNumber = CurrentNumber.Sqr();
                    break;
                case 23: // 1/x
                    CurrentNumber = CurrentNumber.Rev();
                    break;
                case 21: // *(-1)
                    CurrentNumber = CurrentNumber.Negative();
                    break;
                default:
                    break;
            }
        }

        public void PerformOperationOnTwoOperands()
        {
            if (isLeftOperand && bufferOperation == '0' || leftOperand.IsEmpty()) return;

            // Если введено только первое число и в буфере что-то лежит, 
            // то есть до этой выполнялась другая бинарная операция. Случай для повторного нажатия =
            if (isLeftOperand && NoOperator())
            {
                rightOperand = bufferNumber.Copy();
                Operator = bufferOperation;
            }
            else if (!isLeftOperand && rightOperand.IsEmpty()) // Если введено первое число и операция, но не введено второе число, то есть случай операций  +=, -=, *=, /=
            {
                rightOperand = leftOperand.Copy(); // правый операнд созраняем в левый
            }
            // Если ни одно из условий не сработало, то выполняется обычное вычисление

            // Сохраним данные в буфер на случай повторного вычисления
            bufferNumber = rightOperand.Copy();
            bufferOperation = Operator;

            // Вычислим и запишем результат в leftOperand
            switch (Operator)
            {
                case '+':
                    leftOperand = leftOperand.Add(rightOperand);
                    break;
                case '-':
                    leftOperand = leftOperand.Sub(rightOperand);
                    break;
                case '*':
                    leftOperand = leftOperand.Mul(rightOperand);
                    break;
                case '/':
                    leftOperand = leftOperand.Div(rightOperand);
                    break;
                default:
                    break;
            }

            isLeftOperand = true;
            // Удалить лишнее
            editor.Clear(rightOperand);
            ResetOperator();
        }
        //работа с памятью
        public void MPlus()
        {
            if (!isLeftOperand && !rightOperand.IsEmpty()) PerformOperationOnTwoOperands();

            if (savedNumber.IsEmpty()) savedNumber = leftOperand.Copy();
            else
                savedNumber = savedNumber.Add(leftOperand);
        }

        public void MS()
        {
            if (!isLeftOperand && !rightOperand.IsEmpty()) PerformOperationOnTwoOperands();

            savedNumber = leftOperand.Copy();
        }

        public void MR()
        {
            if (!savedNumber.IsEmpty())
                CurrentNumber = savedNumber.Copy();
        }

        public void MC()
        {
            editor.Clear(savedNumber);
        }
    }
}
