using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            Array.Sort(a);

            int height = (int)Math.Log(a.Length, 2);

            int[] bbstArray = new int[(int)Math.Pow(2, height + 1) - 1];

            GenerateBBSTArray(a, 0, a.Length - 1, bbstArray, 0);

            return bbstArray;
        }

        private static int GenerateBBSTArray(int[] sortedArray, int start, int end, int[] bbstArray, int currentIndex)
        {
            if (start > end)
            {
                return currentIndex;
            }

            int mid = (start + end) / 2;

            bbstArray[currentIndex] = sortedArray[mid];

            GenerateBBSTArray(sortedArray, start, mid - 1, bbstArray, 2 * currentIndex + 1);
            GenerateBBSTArray(sortedArray, mid + 1, end, bbstArray, 2 * currentIndex + 2);

            return currentIndex;
        }
    }
}