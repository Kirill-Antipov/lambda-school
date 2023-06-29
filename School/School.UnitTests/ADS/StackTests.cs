using AlgorithmsDataStructures;
using Xunit;

namespace School.UnitTests.ADS
{
    public class StackTests
    {
        [Fact]
        public void Push_AddsElementToStack()
        {
            var stack = new Stack<int>();

            stack.Push(0);
            stack.Push(1);

            Assert.Equal(2, stack.Size());
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void Pop_RemovesAndReturnsTopElement()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);

            int poppedElement = stack.Pop();

            Assert.Equal(1, stack.Size());
            Assert.Equal(1, poppedElement);
        }

        [Fact]
        public void Peek_ReturnsTopElementWithoutRemovingIt()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);

            int peekedElement = stack.Peek();

            Assert.Equal(2, stack.Size());
            Assert.Equal(1, peekedElement);
        }

        [Fact]
        public void Size_ReturnsCurrentStackSize()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);

            int size = stack.Size();

            Assert.Equal(2, size);
        }
    }
}
