using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AlgorithmsDataStructures
{

    public class PowerSet<T>
    {
        public int size;
        public int step;
        public T[] slots;
        public List<T> values;

        public PowerSet()
        {
            size = 20000;
            step = 3;
            slots = new T[size];
            values = new List<T>(size);
        }

        public int Size()
        {
            return values.Count;
        }

        public void Put(T value)
        {
            if (Get(value))
            {
                return;
            }

            int index = SeekSlot(value);

            if (index != -1)
            {
                slots[index] = value;
                values.Add(value);
            }
        }

        public bool Get(T value)
        {
            return Find(value) != -1;
        }

        public bool Remove(T value)
        {
            var index = Find(value);
            if (index == -1)
            {
                return false;
            }

            slots[index] = default(T);
            values.Remove(value);

            return true;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();

            foreach (T item in values)
            {
                if (set2.Get(item))
                {
                    result.Put(item);
                }
            }

            return result;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();

            foreach (T item in values)
            {
                result.Put(item);
            }

            foreach (T item in set2.values)
            {
                result.Put(item);
            }

            return result;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();

            foreach (T item in values)
            {
                if (!set2.Get(item))
                {
                    result.Put(item);
                }
            }

            return result;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            foreach (var item in values)
            {
                if (!set2.Get(item))
                {
                    return false;
                }
            }

            return true;
        }

        private int SeekSlot(T value)
        {
            var hash = GetHashCode(value);
            int index = hash;

            for (int i = 0; i < size; i++)
            {
                if (slots[index] == null)
                {
                    return index;
                }

                index = StepNext(hash, i);
            }

            return -1;
        }

        public int Find(T value)
        {
            int hash = GetHashCode(value);
            int index = hash;

            for (int i = 0; i < size; i++)
            {
                if (slots[index] != null && slots[index].Equals(value))
                {
                    return index;
                }

                index = StepNext(hash, i);
            }

            return -1;
        }

        private int GetHashCode(T value)
        {
            return Math.Abs(value.GetHashCode()) % size;
        }

        private int StepNext(int index, int i)
        {
            return (index + i * step) % size;
        }
    }
}