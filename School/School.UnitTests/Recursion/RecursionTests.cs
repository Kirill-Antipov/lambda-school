using AlgorithmsDataStructures;
using School.Recursion;
using Xunit;

namespace School.UnitTests.Recursion
{
    public class RecursionTests
    {
        [Theory]
        [InlineData(12, 0, 1)]
        [InlineData(1, 9, 1)]
        [InlineData(2, 9, 512)]
        public void Pow_Returns_CorrectResult(int number, int power, int expectedResult)
        {
            var result = Task1.Pow(number, power);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 1)]
        [InlineData(-10, 1)]
        [InlineData(111, 3)]
        [InlineData(123456789, 45)]
        public void SumDigits_Returns_CorrectResult(int number, int expectedResult)
        { 
            var result = Task2.SumDigitsInNumber(number);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Length_Returns_CorrectResult()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(1);
            stack.Push(1);
            stack.Push(1);
            stack.Push(1);

            var result = Task3.Length(stack);

            Assert.True(result == 5);
        }

        [Fact]
        public void Length_Returns_Zero_On_EmptyStack()
        {
            var stack = new Stack<int>();

            var result = Task3.Length(stack);

            Assert.True(result == 0);
        }

        [Theory]
        [InlineData("palindrome", false)]
        [InlineData("abba", true)]
        public void IsPalindrome_Returns_CorrectResult(string word, bool expetcedResut)
        {
            var result = Task4.IsPalindrome(word);

            Assert.Equal(expetcedResut, result);
        }
    }
}
