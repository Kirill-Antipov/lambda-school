using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        private const int defaultCapacity = 16;

        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(defaultCapacity);
        }

        public void MakeArray(int new_capacity)
        {
            var newArray = new T[new_capacity];

            if (array != null)
            {
                Array.Copy(array, newArray, count);
            }

            array = newArray;
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            return array[index];
        }

        public void Append(T itm)
        {
            if (count == array.Length)
            {
                MakeArray(capacity * 2);
            }

            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if (count == capacity)
            {
                MakeArray(capacity * 2);
            }

            Array.Copy(array, index, array, index + 1, count - index);
            array[index] = itm;
            count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            Array.Copy(array, index + 1, array, index, count - index - 1);
            count--;

            if (count <= capacity / 2 && capacity > defaultCapacity)
            {
                int decreasedCapacity = (int)(capacity / 1.5);
                int newCapacity = Math.Max(decreasedCapacity, defaultCapacity);
                MakeArray(newCapacity);
            }
        }
    }
}