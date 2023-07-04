using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        private List<T> _list;

        public Queue()
        {
            _list = new List<T>();
        }

        public void Enqueue(T item)
        {
            _list.Add(item);
        }

        public T Dequeue()
        {
            if (_list.Count == 0)
            {
                return default(T);
            }

            T item = _list[0];
            _list.RemoveAt(0);

            return item;
        }

        public int Size()
        {
            return _list.Count;
        }

    }
}