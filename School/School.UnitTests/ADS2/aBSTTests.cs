using AlgorithmsDataStructures2;
using Xunit;

namespace School.UnitTests.ADS2
{
    public class aBSTTests
    {
        [Fact]
        public void Tree_Array_Structure_Correct()
        {
            var tree = new aBST(2);

            tree.AddKey(6);
            tree.AddKey(4);
            tree.AddKey(8);
            tree.AddKey(3);
            tree.AddKey(5);
            tree.AddKey(7);
            tree.AddKey(9);

            var expectedResult = new int[] { 6, 4, 8, 3, 5, 7, 9 };

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(tree.Tree[i], expectedResult[i]);
            }
        }

        [Fact]
        public void Key_Added()
        {
            var tree = new aBST(2);

            var resultIndex = tree.AddKey(6);

            Assert.Equal(0, resultIndex);

            resultIndex = tree.AddKey(4);

            Assert.Equal(1, resultIndex);
        }

        [Fact]
        public void Key_Not_Added_When_Tree_Full()
        {
            var tree = new aBST(2);

            tree.AddKey(4);
            tree.AddKey(8);
            tree.AddKey(3);
            tree.AddKey(5);
            tree.AddKey(7);
            tree.AddKey(9);

            var resultIndex = tree.AddKey(10);

            Assert.Equal(-1, resultIndex);
        }

        [Fact]
        public void Index_Returned_When_Key_Exists()
        {
            var tree = new aBST(2);

            tree.AddKey(6);
            tree.AddKey(4);
            tree.AddKey(8);

            var resultIndex = tree.AddKey(3);

            Assert.Equal(3, resultIndex);

            resultIndex = tree.AddKey(3);

            Assert.Equal(3, resultIndex);
        }

        [Fact]
        public void KeyIndex_Found()
        {
            var tree = new aBST(2);

            tree.AddKey(6);
            tree.AddKey(4);
            tree.AddKey(8);
            tree.AddKey(3);

            var resultIndex = tree.FindKeyIndex(3);

            Assert.Equal(3, resultIndex);
        }

        [Fact]
        public void Null_Index_Found_When_Tree_Full()
        {
            var tree = new aBST(2);

            tree.AddKey(4);
            tree.AddKey(8);
            tree.AddKey(3);
            tree.AddKey(5);
            tree.AddKey(7);
            tree.AddKey(9);

            var resultIndex = tree.FindKeyIndex(10);

            Assert.Null(resultIndex);
        }

        [Fact]
        public void Future_Index_For_Key_Found_Negative()
        {
            var tree = new aBST(2);

            tree.AddKey(6);
            tree.AddKey(4);
            tree.AddKey(8);
            tree.AddKey(3);

            var resultIndex = tree.FindKeyIndex(5);

            Assert.Equal(-4, resultIndex);
        }
    }
}
