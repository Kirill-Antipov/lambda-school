using System;

namespace School.Recursion
{
    public class Task2
    {
        public static int SumDigitsInNumber(int number)
        {
            number = Math.Abs(number);

            if (number < 10)
            {
                return number;
            }

            return number % 10 + SumDigitsInNumber(number / 10);
        }
    }
}
