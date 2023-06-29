using AlgorithmsDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.ADS
{
    public class StackTasks
    {
        public static bool IsBracesSequenceBalanced(string input)
        {
            var stack = new AlgorithmsDataStructures.Stack<char>();

            foreach (char c in input)
            {
                if (c == '(')
                {
                    stack.Push(c);
                    continue;
                }

                if (stack.Size() == 0 || stack.Pop() != '(')
                {
                    return false;
                }
            }

            return stack.Size() == 0;
        }

        public static int ProcessPostfixExpression(AlgorithmsDataStructures.Stack<char> expression)
        {
            var operations = new Dictionary<char, Func<int, int, int>>()
            {
                {'+', (a, b) => {return a + b; } },
                {'*', (a, b) => {return a * b; } },
            };

            var operands = new AlgorithmsDataStructures.Stack<int>();

            while (expression.Size() > 0)
            {
                var symbol = expression.Pop();

                if (operations.ContainsKey(symbol))
                {
                    var operand2 = operands.Pop();
                    var operand1 = operands.Pop();
                    var result = operations[symbol](operand1, operand2);
                    operands.Push(result);
                    continue;
                }

                if (symbol == '=')
                {
                    return operands.Pop();
                }

                operands.Push(int.Parse(symbol.ToString()));
            }

            throw new Exception("Incorrectly formed expression");
        }
    }
}
