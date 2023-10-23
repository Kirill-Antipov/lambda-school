using System.Collections.Generic;

namespace School.Recursion
{
    public class Task7
    {
        public static int GetSecondMaxElement(List<int> input)
        {
            return GetSecondMaxElement(input, 1, input[0], int.MinValue);
        }

        private static int GetSecondMaxElement(List<int> input, int current, int max, int result)
        {
            if (input.Count == current)
            {
                return result;
            }

            if (input[current] >= max)
            {
                return GetSecondMaxElement(input, current + 1, input[current], max);
            }

            if (input[current] >= result)
            {
                return GetSecondMaxElement(input, current + 1, max, input[current]);
            }

            return GetSecondMaxElement(input, current + 1, max, result);
        }
    }
}
