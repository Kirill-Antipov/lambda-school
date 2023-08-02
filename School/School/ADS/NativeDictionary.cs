using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        private int count;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash += (int)c;
            }

            return hash % size;
        }

        public bool IsKey(string key)
        {
            int hash = HashFun(key);
            int i = 0;
            int index = hash;

            while (slots[index] != null && slots[index] != key)
            {
                i++;
                if (i == size)
                {
                    return false;
                }

                index = StepNext(hash, i);
            }

            if (slots[index] != null && slots[index] == key)
            {
                return true;
            }

            return false;
        }

        public void Put(string key, T value)
        {
            TryResize();
            var index = SeekSlot(key);

            slots[index] = key;
            values[index] = value;
            count++;
        }

        public T Get(string key)
        {
            int hash = HashFun(key);
            int i = 0;
            int index = hash;

            while (slots[index] != null && slots[index] != key)
            {
                i++;
                if (i == size)
                {
                    return default(T);
                }

                index = StepNext(hash, i);
            }

            if (slots[index] != null && slots[index] == key)
            {
                return values[index];
            }

            return default(T);
        }

        private int SeekSlot(string key)
        {
            int i = 0;
            var hash = HashFun(key);
            int index = hash;

            while (slots[index] != null)
            {
                i++;
                if (slots[index] == key)
                {
                    return index;
                }

                index = StepNext(hash, i);

                if (i == size)
                {
                    return -1;
                }
            }

            return index;
        }

        private int StepNext(int index, int i)
        {
            return (index + i * 3) % size;
        }

        public void TryResize()
        {
            if (count == 0)
            {
                return;
            }

            if (count / size < 0.78)
            {
                return;
            }

            size *= 3;
            Array.Resize(ref slots, size);
            Array.Resize(ref values, size);
        }
    }
}