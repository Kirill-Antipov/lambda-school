using System.Collections.Generic;

namespace School.Recursion
{
    public class Task9
    {
        public static List<string> GenerateParenthesisCombinations(int leftParentheses)
        {
            var result = new List<string>();
            GenerateParenthesisCombinations(leftParentheses, leftParentheses, "", result);

            return result;
        }

        private static void GenerateParenthesisCombinations(int left, int right, string current, List<string> result)
        {
            if (left == 0 && right == 0)
            {
                result.Add(current);
                return;
            }

            if (left > 0)
            {
                GenerateParenthesisCombinations(left - 1, right, current + "(", result);
            }

            if (right > left)
            {
                GenerateParenthesisCombinations(left, right - 1, current + ")", result);
            }
        }
    }
}
