using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    class Control
    {
        public enum TypeEditor
        {
            PNum = 1,
            CNum = 2,
            FNum = 3
        }

        public TProc processor;

        public Control(int type)
        {
            processor = new TProc(type);
        }

        public int State { 
            get { return processor.State; }
            set { processor.State = value; } 
        }

        public string Text { get { return processor.Text; } }


        public void AddDigit(int value)
        {
            char tmp = Conver_10_p.int_to_Char(value);
            processor.AddDigit(tmp);
        }

        
        public void AddDelim()
        {
            processor.AddDelim();
        }

        public void DoUnaryOperation(int value)
        {
            processor.DoUnaryOperation(value);
        }

        public void Clear()
        {
            processor.Reset();
        }

        public void ClearCurrent()
        {
            processor.ResetCurNum();
        }

        public void Backspace()
        {
            processor.Bs();
        }

        public void DoCommand(int tag, int tag2=0)
        {
            switch (tag)
            {
                case -1:
                case -2: processor.ChangeState(tag); break;
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15: AddDigit(tag); break;

                case 16: processor.SetOperator('+'); break;
                case 17: processor.SetOperator('-'); break;
                case 18: processor.SetOperator('*'); break;
                case 19: processor.SetOperator('/');  break;

                case 20: AddDelim(); break;
                case 21: 
                case 22: processor.ChangeSign(); break;
                case 23: 
                case 24: DoUnaryOperation(tag2); break;

                case 25: ClearCurrent(); break;
                case 31: Clear(); break;
                case 32: Backspace(); break;

                case 26: processor.MPlus(); break;
                case 27: processor.MS(); break;
                case 28: processor.MR(); break;
                case 29: processor.MC(); break;

                case 33: processor.PerformOperationOnTwoOperands(); break;
            }
        }
    }
}
