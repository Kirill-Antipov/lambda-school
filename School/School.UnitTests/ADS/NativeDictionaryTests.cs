using AlgorithmsDataStructures;
using Xunit;

namespace School.UnitTests.ADS
{
    public class NativeDictionaryTests
    {
        [Fact]
        public void Put_Adds_Value()
        {
            var sut = new NativeDictionary<string>(19);

            sut.Put("key1", "value1");

            var resultKey = sut.IsKey("key1");
            var resultValue = sut.Get("key1");

            Assert.True(resultKey);
            Assert.True(resultValue == "value1");
        }

        [Fact]
        public void Put_Adds_Additional_Value_When_Collision_Exists()
        {
            var sut = new NativeDictionary<string>(19);

            sut.Put("key1", "value1");
            sut.Put("1key", "value2");

            var resultKey = sut.IsKey("1key");
            var resultValue = sut.Get("1key");

            Assert.True(resultKey);
            Assert.True(resultValue == "value2");

            resultKey = sut.IsKey("key1");
            resultValue = sut.Get("key1");

            Assert.True(resultKey);
            Assert.True(resultValue == "value1");
        }

        [Fact]
        public void Put_Updates_Value()
        {
            var sut = new NativeDictionary<string>(19);

            sut.Put("key1", "value1");
            sut.Put("key1", "value100");

            var resultValue = sut.Get("key1");

            Assert.True(resultValue == "value100");
        }

        [Fact]
        public void Dictionary_Resized_When_Capacity_Large()
        {
            var sut = new NativeDictionary<string>(5);

            sut.Put("key1", "value1");
            sut.Put("key2", "value2");
            sut.Put("key3", "value3");
            sut.Put("key4", "value4");
            sut.Put("key5", "value5");
            sut.Put("key6", "value6");

            Assert.True(sut.size == 15);
        }

        [Fact]
        public void IsKey_False_When_NoKey()
        {
            var sut = new NativeDictionary<string>(19);

            var resultKey = sut.IsKey("key1");

            Assert.False(resultKey);
        }

        [Fact]
        public void Get_Null_When_NoKey()
        {
            var sut = new NativeDictionary<string>(19);

            var result = sut.Get("key1");

            Assert.Null(result);
        }
    }
}
