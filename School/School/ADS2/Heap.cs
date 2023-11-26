using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {
        public int[] HeapArray;

        public int CurrentSize;

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            int maxElements = (int)Math.Pow(2, depth + 1) - 1;

            if (a.Length > maxElements)
            {
                throw new ArgumentException($"Specified depth is incorrect. Depth: {depth}, initial array size: {a.Length}");
            }

            HeapArray = new int[maxElements];
            CurrentSize = a.Length;

            for (int i = 0; i < a.Length; i++)
            {
                HeapArray[i] = a[i];
            }

            for (int i = (HeapArray.Length - 2) / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public int GetMax()
        {
            if (CurrentSize == 0)
            {
                return -1;
            }

            int max = HeapArray[0];
            HeapArray[0] = HeapArray[CurrentSize - 1];
            CurrentSize--;
            Heapify(0);

            return max;
        }

        public bool Add(int key)
        {
            if (CurrentSize == HeapArray.Length)
            {
                return false;
            }

            HeapArray[CurrentSize] = key;
            CurrentSize++;

            SiftUp(CurrentSize - 1);

            return true;
        }

        private void Heapify(int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int largest = index;

            if (leftChild < CurrentSize && HeapArray[leftChild] > HeapArray[largest])
            {
                largest = leftChild;
            }

            if (rightChild < CurrentSize && HeapArray[rightChild] > HeapArray[largest])
            {
                largest = rightChild;
            }

            if (largest != index)
            {
                Swap(index, largest);
                Heapify(largest);
            }
        }

        private void Swap(int i, int j)
        {
            int temp = HeapArray[i];
            HeapArray[i] = HeapArray[j];
            HeapArray[j] = temp;
        }

        private void SiftUp(int index)
        {
            if (index <= 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            if (HeapArray[index] > HeapArray[parentIndex])
            {
                Swap(index, parentIndex);
                SiftUp(parentIndex);
            }
        }
    }
}