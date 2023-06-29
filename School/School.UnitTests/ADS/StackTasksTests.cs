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

    }
}
