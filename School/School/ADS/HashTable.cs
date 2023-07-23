using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            int hash = 0;
            foreach (char c in value)
            {
                hash += (int)c;
            }
            return hash % size;
        }

        public int SeekSlot(string value)
        {
            int i = 0;
            var hash = HashFun(value);
            int index = hash;

            while (slots[index] != null)
            {
                i++;
                index = StepNext(hash, i);

                if (i == size)
                {
                    return -1;
                }
            }

            return index;
        }

        public int Put(string value)
        {
            int index = SeekSlot(value);

            if (index != -1)
            {
                slots[index] = value;
            }

            return index;
        }

        public int Find(string value)
        {
            int hash = HashFun(value);
            int i = 0;
            int index = hash;

            while (slots[index] != null && slots[index] != value)
            {
                i++;
                if (i == size)
                {
                    return -1;
                }

                index = StepNext(hash, i);
            }

            if (slots[index] != null)
            {
                return index;
            }

            return -1;
        }

        private int StepNext(int index, int i)
        {
            return (index + i * step) % size;
        }
    }

}