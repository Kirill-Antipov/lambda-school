using AlgorithmsDataStructures2;
using Xunit;

namespace School.UnitTests.ADS2
{
    public class BBSTTests
    {
        [Fact]
        public void BalancedTree_Array_Created_Height_1()
        {
            var inputArray = new int[] { 2, 3, 1 };
            var treeArray = BBST.GenerateBBSTArray(inputArray);

            Assert.Equal(3, treeArray.Length);

            var expectedResult = new int[] { 2, 1, 3, };

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(treeArray[i], expectedResult[i]);
            }
        }

        [Fact]
        public void BalancedTree_Array_Created_Height_3()
        {
            var inputArray = new int[] { 3, 4, 5, 9, 8, 7 ,6 };
            var treeArray = BBST.GenerateBBSTArray(inputArray);

            Assert.Equal(7, treeArray.Length);

            var expectedResult = new int[] { 6, 4, 8, 3, 5, 7, 9 };

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(treeArray[i], expectedResult[i]);
            }
        }
    }
}
