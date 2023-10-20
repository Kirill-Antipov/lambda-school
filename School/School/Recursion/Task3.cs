using AlgorithmsDataStructures;

namespace School.Recursion
{
    public class Task3
    {
        public static int Length(Stack<int> stack)
        {
            var result = stack.Pop();

            if (result == 0)
            {
                return 0;
            }

            return 1 + Length(stack);
        }
    }
}
