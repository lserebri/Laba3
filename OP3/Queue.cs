using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class Queue<T>
    {
        private int _Front = -1;
        private int _Rear = -1;
        private int _Count = 0;
        private readonly int _Size;
        private readonly T[] _Array;
        public Queue(int Size)
        {
            this._Size = Size;
            this._Array = new T[Size];
        }
        public bool IsFull()
        {
            return _Rear == _Size - 1;
        }

        public bool IsEmpty()
        {
            return _Count == 0;
        }
        public void Enqueue(T Item)
        {
            if (this.IsFull())
                throw new Exception("Очередь полностью заполнена.");

            _Array[++_Rear] = Item;
            _Count++;
        }
        public T Dequeue()
        {
            if (this.IsEmpty())
                throw new Exception("Очередь не заполнена.");

            T value = _Array[++_Front];
            _Count--;
            if (_Front == _Rear)
            {
                _Front = -1;
                _Rear = -1;
            }
            return value;
        }
        public int Size
        {
            get { return _Size; }
        }

        public int Count
        {
            get { return _Count; }
        }
        public T Peek()
        {
            if (this.IsEmpty())
                throw new Exception("Очередь не заполнена.");

            T value = _Array[_Front + 1];
            return value;
        }

    }
}
