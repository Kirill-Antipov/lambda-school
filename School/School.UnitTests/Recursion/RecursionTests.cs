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
    }
}
