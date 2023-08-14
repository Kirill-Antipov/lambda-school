using AlgorithmsDataStructures;
using Xunit;

namespace School.UnitTests.ADS
{
    public class BloomFilterTests
    {
        [Fact]
        public void BloomFilter_Sustainable()
        {
            var sut = new BloomFilter(32);

            sut.Add("0123456789");

            var result = sut.IsValue("0123456789");

            Assert.True(result);

            result = sut.IsValue("1234567890");

            Assert.False(result);

            var falsePosotoveResult = sut.IsValue("2345678901");

            Assert.True(falsePosotoveResult);
        }
    }
}
