using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private List<T> data;

        public Stack()
        {
            data = new List<T>();
        }

        public int Size()
        {
            return data.Count;
        }

        public T Pop()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var popIndex = data.Count - 1;
            var popElement = data[popIndex];

            data.RemoveAt(popIndex);

            return popElement;
        }

        public void Push(T val)
        {
            data.Add(val);
        }

        public T Peek()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return data[data.Count - 1];
        }
    }

}