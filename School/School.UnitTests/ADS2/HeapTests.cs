using AlgorithmsDataStructures2;
using Xunit;

namespace School.UnitTests.ADS2
{
    public class HeapTests
    {
        [Fact]
        public void Heap_Created()
        {
            var inputArray = new int[] {1, 5, 9, 3, 2, 4 };
            var heap = new Heap();

            heap.MakeHeap(inputArray, 4);

            Assert.True(heap.HeapArray.Length == 31);
            Assert.True(heap.CurrentSize == 6);
            Assert.True(heap.HeapArray[0] == 9);
            Assert.True(heap.HeapArray[5] == 1);
        }

        [Fact]
        public void Max_Element_Retrieved_With_Heap_Rebuild()
        {
            var inputArray = new int[] { 1, 5, 9, 3, 2, 4 };
            var heap = new Heap();

            heap.MakeHeap(inputArray, 4);

            var result = heap.GetMax();

            Assert.Equal(9, result);
            Assert.True(heap.CurrentSize == 5);
            Assert.True(heap.HeapArray[0] == 5);
        }

        [Fact]
        public void Max_Element_Retrieved_When_Heap_Empty()
        {
            var heap = new Heap();

            var result = heap.GetMax();

            Assert.Equal(-1, result);
        }

        [Fact]
        public void Key_Added_To_Heap()
        {
            var inputArray = new int[] { 7, 5, 9, 3, 2, 4 };
            var heap = new Heap();

            heap.MakeHeap(inputArray, 4);

            heap.Add(10);

            Assert.Equal(7, heap.CurrentSize);
            Assert.Equal(10, heap.HeapArray[0]);
        }
    }
}
