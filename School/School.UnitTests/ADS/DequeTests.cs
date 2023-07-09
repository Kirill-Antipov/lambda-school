using AlgorithmsDataStructures;
using System.Runtime.Remoting.Messaging;
using Xunit;

namespace School.UnitTests.ADS
{
    public class DequeTests
    {
        [Fact]
        public void Dequeue_Works_Correctly()
        {
            var sut = new Deque<int>();

            sut.AddFront(1);
            sut.AddFront(0);
            sut.AddTail(2);
            sut.AddTail(3);

            Assert.True(sut.Size() == 4);

            var head = sut.RemoveFront();

            Assert.Equal(0, head);

            var tail = sut.RemoveTail();

            Assert.Equal(3, tail);
        }

        [Fact]
        public void Is_Palindrome()
        {
            var sut = new Deque<string>();

            sut.AddFront("l");
            sut.AddFront("e");
            sut.AddFront("v");
            sut.AddFront("e");
            sut.AddFront("l");

            var isPalindrome = true;

            while (sut.Size() >=2)
            {
                var first = sut.RemoveFront();
                var last = sut.RemoveTail();


                isPalindrome = isPalindrome && first == last;
            }

            Assert.True(isPalindrome);
        }
    }
}
