using System;
using System.Collections.Generic;

namespace School.ADS
{
    public class StackVariation<T>
    {
        private LinkedList<T> data;

        public StackVariation()
        {
            data = new LinkedList<T>();
        }

        public void Push(T value)
        {
            data.AddFirst(value);
        }

        public T Pop()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T poppedValue = data.First.Value;

            data.RemoveFirst();

            return poppedValue;
        }

        public T Peek()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return data.First.Value;
        }

        public int Size()
        {
            return data.Count;
        }
    }
}
