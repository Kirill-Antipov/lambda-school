namespace School.Recursion
{
    public class Task1
    {
        public static int Pow(int number, int power)
        {
            return Pow(number, power, 1);
        }

        private static int Pow(int number, int power, int result)
        {
            if (power == 0)
            {
                return result;
            }

            return Pow(number, --power, result * number);
        }
    }
}
