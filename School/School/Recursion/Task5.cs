using System;
using System.Collections.Generic;

namespace School.Recursion
{
    public class Task5
    {
        public static void PrintEvenNumbers(List<int> numbers)
        {
            PrintEvenNumbers(numbers, 0);
        }

        private static void PrintEvenNumbers(List<int> numbers, int current)
        {
            if (current == numbers.Count)
            {
                return;
            }

            if (numbers[current] % 2 == 0)
            {
                Console.WriteLine(numbers[current]);
            }

            PrintEvenNumbers(numbers, ++current);
        }
    }
}
