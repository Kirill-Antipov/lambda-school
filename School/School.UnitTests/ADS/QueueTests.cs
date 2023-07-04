using AlgorithmsDataStructures;
using Xunit;

namespace School.UnitTests.ADS
{
    public class QueueTests
    {
        [Fact]
        public void Queue_Works_Correctly()
        {
            var sut = new Queue<int>();

            sut.Enqueue(1);
            sut.Enqueue(2);
            sut.Enqueue(3);

            var result = sut.Dequeue();

            Assert.True(result == 1);
            Assert.True(sut.Size() == 2);
        }
    }
}
