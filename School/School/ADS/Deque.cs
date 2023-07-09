using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Deque<T>
    {
        private LinkedList<T> deque;

        public Deque()
        {
            deque = new LinkedList<T>();
        }

        public void AddFront(T item)
        {
            deque.AddFirst(item);
        }

        public void AddTail(T item)
        {
            deque.AddLast(item);
        }

        public T RemoveFront()
        {
            if (deque.Count == 0)
            {
                return default(T);
            }

            var item = deque.First.Value;
            deque.RemoveFirst();

            return item;
        }

        public T RemoveTail()
        {
            if (deque.Count == 0)
            {
                return default(T);
            }

            var item = deque.Last.Value;
            deque.RemoveLast();

            return item;
        }

        public int Size()
        {
            return deque.Count;
        }
    }

}