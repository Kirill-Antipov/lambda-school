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

            int currentMax = input[current] >= max ? input[current] : max;
            int currentResult = result;

            if (input[current] >= max)
            {
                currentResult = max;
            }
            else if (input[current] >= result)
            {
                currentResult = input[current];
            }

            return GetSecondMaxElement(input, current + 1, currentMax, currentResult);
        }
    }
}
