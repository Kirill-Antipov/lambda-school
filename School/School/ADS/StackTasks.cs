using System.Collections.Generic;

namespace School.ADS
{
    public class StackTasks
    {
        public static bool IsBracesSequenceBalanced(string input)
        {
            var stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(')
                {
                    stack.Push(c);
                    continue;
                }

                if (stack.Count == 0 || stack.Pop() != '(')
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
