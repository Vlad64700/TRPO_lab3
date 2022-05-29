using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_lab3
{
    class TMemory<T> where T: TANumber, new()
    {
        //число, хранящееся в памяти
        private T _fNumber;

        //состояние памяти
        private State _fState;

        enum State
        {
            _Off,
            _On
        };

        public TMemory()
        {
            //храним нулевое число - это значение по умолчанию
            _fNumber = new T();
            _fState = State._Off;
        }

        // В объект «память»в поле FNumber записывается копия объекта
        // память устанавливается в состояние «Включена», 
        public void Write(T num)
        {
            _fNumber = (T)num.Copy();
            _fState = State._On;
        }

        // Создаёт и возвращает копию объекта хранящегося в объекте «память» 
        public T Take()
        {
            _fState = State._On;
            return (T)_fNumber.Copy();
        }

        // В поле FNumber объекта «память» (тип TMemory) записывается объект
        // полученный в результате сложения числа num
        // и числа, хранящегося в памяти в поле FNumber. 
        public void Add(T num)
        {
            if (_fState == State._Off)
            {
                Write(num);
            }
            else _fNumber = (T)_fNumber.Add(num);

        }

        //В поле числа(FNumber) объекта «память» (тип TMemory) записывается значение по умолчанию
        //Память(поле _fState) устанавливается в состояние _Off.
        public void Clear()
        {
            //храним нулевое число - это значение по умолчанию
            _fNumber = new T();
            _fState = State._Off;
        }

        public string GetState() => _fState.ToString();

        public T GetNumber() => _fNumber;

    }
}
