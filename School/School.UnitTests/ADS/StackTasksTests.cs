using AlgorithmsDataStructures;
using School.ADS;
using Xunit;

namespace School.UnitTests.ADS
{
    public class StackTasksTests
    {
        [Theory]
        [InlineData("(()((())()))", true)]
        [InlineData("(()((()()))", false)]
        public void Correct_Braces_Balanced_Result(string input, bool expectedResult)
        {
            var result  = StackTasks.IsBracesSequenceBalanced(input);

            Assert.True(result == expectedResult);
        }

        [Fact]
        public void PostfixExpression_Calculates_Correctly()
        {
            var expression = new Stack<char>();

            expression.Push('=');
            expression.Push('*');
            expression.Push('3');
            expression.Push('+');
            expression.Push('1');
            expression.Push('2');

            var result = StackTasks.ProcessPostfixExpression(expression);

            Assert.True(result == 9);
        }
    }
}
