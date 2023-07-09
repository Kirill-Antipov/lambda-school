using AlgorithmsDataStructures;
using Xunit;

namespace School.UnitTests.ADS
{
    public class OrderedListTests
    {
        [Fact]
        public void OrderedList_Count_Gives_Correct_Result()
        {
            var sut = new OrderedList<int>(true);

            sut.Add(5);
            sut.Add(2);
            sut.Add(1);
            sut.Add(3);
            sut.Add(4);

            Assert.True(sut.Count() == 5);
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(5, false)]
        public void OrderedList_Find_Returns_Correct_Result(int valueToFind, bool exists)
        {
            var sut = new OrderedList<int>(true);

            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            var result = sut.Find(valueToFind);

            if (exists)
            {
                Assert.True(result.value == valueToFind);
            }
            else
            {
                Assert.Null(result);
            }
        }

        [Fact]
        public void OrderedList_Delete_Removes_Node()
        {
            var sut = new OrderedList<int>(true);

            sut.Add(5);
            sut.Add(2);
            sut.Add(1);
            sut.Add(3);
            sut.Add(4);

            sut.Delete(3);
            var result = sut.Find(3);

            Assert.True(sut.Count() == 4);
            Assert.Null(result);
        }

        [Fact]
        public void OrderList_Correctly_Ordered_Asc()
        {
            var sut = new OrderedList<int>(true);

            sut.Add(5);
            sut.Add(2);
            sut.Add(1);
            sut.Add(3);
            sut.Add(4);

            var node = sut.head;
            var i = 1;

            while (node != null)
            {
                Assert.True(node.value == i++);
                node = node.next;
            }
        }

        [Fact]
        public void OrderList_Correctly_Ordered_Desc()
        {
            var sut = new OrderedList<int>(false);

            sut.Add(5);
            sut.Add(2);
            sut.Add(1);
            sut.Add(3);
            sut.Add(4);

            var node = sut.head;
            var i = 5;

            while (node != null)
            {
                Assert.True(node.value == i--);
                node = node.next;
            }
        }
    }
}
