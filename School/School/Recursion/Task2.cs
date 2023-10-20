using System;

namespace School.Recursion
{
    public class Task2
    {
        public static int SumDigitsInNumber(int number)
        {
            number = Math.Abs(number);

            return SumDigits(number);
        }

        private static int SumDigits(int number)
        {
            if (number < 10)
            {
                return number;
            }

            return number % 10 + SumDigits(number / 10);
        }
    }
}
