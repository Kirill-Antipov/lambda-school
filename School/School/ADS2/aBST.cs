using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree;

        public aBST(int depth)
        {
            int tree_size = (int)Math.Pow(2, depth + 1) - 1;
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            return FindKeyIndex(0, key);
        }

        public int AddKey(int key)
        {
            return AddKey(0, key);
        }

        private int? FindKeyIndex(int currentIndex, int key)
        {
            if (currentIndex >= Tree.Length)
            {
                return null;
            }

            if (Tree[currentIndex] == null)
            {
                return -currentIndex;
            }

            int currentKey = Tree[currentIndex].Value;

            if (key == currentKey)
            {
                return currentIndex;
            }

            if (key < currentKey)
            {
                return FindKeyIndex(2 * currentIndex + 1, key);
            }
            
            return FindKeyIndex(2 * currentIndex + 2, key);
        }

        private int AddKey(int currentIndex, int key)
        {
            if (currentIndex >= Tree.Length)
            {
                return -1;
            }

            if (Tree[currentIndex] == null)
            {
                Tree[currentIndex] = key;
                return currentIndex;
            }

            int currentKey = Tree[currentIndex].Value;

            if (key == currentKey)
            {
                return currentIndex;
            }

            if (key < currentKey)
            {
                return AddKey(2 * currentIndex + 1, key);
            }
            
            return AddKey(2 * currentIndex + 2, key);
        }
    }
}