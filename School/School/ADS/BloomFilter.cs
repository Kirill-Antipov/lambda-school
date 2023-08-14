using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public int filter;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            filter = 0;
        }

        public int Hash1(string str1)
        {
            return Hash(str1, 17);
        }

        public int Hash2(string str1)
        {
            return Hash(str1, 223);
        }

        public void Add(string str1)
        {
            var mask = GetMask(str1);

            filter |= mask;
        }

        public bool IsValue(string str1)
        {
            var mask = GetMask(str1);
            return (filter & mask) != 0;
        }

        private int GetMask(string str1)
        {
            var hashCollection = new int[] { Hash1(str1), Hash2(str1) };
            var mask = 0;

            foreach (var hash in hashCollection)
            {
                var shift = hash == 0 ? hash : hash - 1;
                mask |= 1 << shift;
            }

            return mask;
        }

        private int Hash(string value, int rnd)
        {
            int hash = 0;
            for (int i = 0; i < value.Length; i++)
            {
                hash *= rnd;
                hash += (int)value[i];
                hash %= filter_len;
            }

            return hash;
        }
    }
}