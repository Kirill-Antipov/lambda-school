using AlgorithmsDataStructures;
using School.Recursion;
using System.Collections.Generic;
using System.Linq;
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
            var stack = new AlgorithmsDataStructures.Stack<int>();

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
            var stack = new AlgorithmsDataStructures.Stack<int>();

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

        [Theory]
        [InlineData(5, 2, 5, 4, 3, 5)]
        [InlineData(5, 5, 1 ,1, 1, 1, 1, 5)]
        [InlineData(1, 1, 1, 2, 1, 1)]
        [InlineData(2, 3, 2)]
        public void GetSecondMaxElement_Returns_Correct_Result(int expectedResult, params int[] input)
        {
            var result = Task7.GetSecondMaxElement(input.ToList());

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Find_All_Files()
        {
            var result = Task8.GetAllFiles("../../../Recursion/TestFiles");

            Assert.Equal(5, result.Count);

            var fileNames = result.Select(_ => _.Split('\\').Last()).ToList();

            Assert.Contains("file.txt", fileNames);
            Assert.Contains("file1.txt", fileNames);
            Assert.Contains("file2.txt", fileNames);
            Assert.Contains("file3.txt", fileNames);
            Assert.Contains("file4.txt", fileNames);
        }

        [Fact]
        public void Should_Generate_All_Combinations()
        {
            var result = Task9.GenerateParenthesisCombinations(3);

            Assert.Equal(5, result.Count);

            Assert.Contains("((()))", result);
            Assert.Contains("(()())", result);
            Assert.Contains("(())()", result);
            Assert.Contains("()(())", result);
            Assert.Contains("()()()", result);
        }
    }
}
