using System;
using System.Collections.Generic;

namespace School.Recursion
{
    public class Task6
    {
        public static void PrintEvenElements<T>(List<T> numbers)
        {
            PrintEvenElements(numbers, 0);
        }

        private static void PrintEvenElements<T>(List<T> numbers, int current)
        {
            if (current == numbers.Count)
            {
                return;
            }

            if (current % 2 == 0)
            {
                Console.WriteLine(numbers[current]);
            }

            PrintEvenElements(numbers, ++current);
        }
    }
}
