using AlgorithmsDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace School.UnitTests.ADS
{
    public class DynArrayTests
    {
        [Fact]
        public void Can_Create_Array()
        {
            var sut = new DynArray<int>();

            sut.Append(1);

            Assert.True(sut.count == 1);
            Assert.True(sut.capacity == 16);
        }

        [Fact]
        public void Array_Capacity_Enlarged_When_Current_Limit_Reached()
        {
            var sut = InitArray(16);

            sut.Append(16);

            Assert.True(sut.count == 17);
            Assert.True(sut.capacity == 32);
            Assert.True(sut.GetItem(0) == 0);
            Assert.True(sut.GetItem(16) == 16);
        }

        [Fact]
        public void Throws_Exception_On_OutOfBoundary_Call()
        {
            var sut = InitArray(16);

            Assert.Throws<IndexOutOfRangeException>(() => sut.GetItem(17));
            Assert.Throws<IndexOutOfRangeException>(() => sut.Insert(9999, 18));
            Assert.Throws<IndexOutOfRangeException>(() => sut.Remove(18));
        }

        [Theory]
        [InlineData(64, 42)]
        [InlineData(20, 16)]
        public void Capacity_Shrinked_When_Half_Space_NotUsed(int initialCapacity, int finalCapacity)
        {
            var sut = InitArray(initialCapacity);

            for (int i = 0; i < initialCapacity/2; i++)
            {
                sut.Remove(2);
            }

            Assert.True(sut.capacity == finalCapacity);
        }

        [Fact]
        public void Element_Removed()
        {
            var sut = InitArray(32);

            sut.Remove(20);

            Assert.True(sut.capacity == 32);
            Assert.True(sut.GetItem(20) == 21);
            Assert.True(sut.GetItem(19) == 19);
        }

        [Fact]
        public void Element_Inserted()
        {
            var sut = InitArray(32);

            sut.Insert(99, 20);

            Assert.True(sut.capacity == 64);
            Assert.True(sut.GetItem(20) == 99);
            Assert.True(sut.GetItem(21) == 20);
        }

        private DynArray<int> InitArray(int length)
        {
            var array = new DynArray<int>();

            for (int i = 0; i < length; i++)
            {
                array.Append(i);
            }

            return array;
        }
    }
}
