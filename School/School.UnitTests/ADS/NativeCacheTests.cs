using System;
using Xunit;

namespace School.UnitTests.ADS
{
    public class NativeCacheTests
    {
        [Fact]
        public void Element_Stored_In_Cache()
        {
            var sut = new NativeCache<string>(3);

            sut.Put("key1", "nice_value");

            Assert.True(sut.Get("key1") == "nice_value");
        }

        [Fact]
        public void Slot_Freed_For_New_Element_When_Capacity_Reached()
        {
            var sut = new NativeCache<string>(5);

            sut.Put("key1", "nice_value");
            sut.Put("ke1y", "good_value");
            sut.Put("k1ey", "sunny_value");
            sut.Put("1key", "stormy_value");
            sut.Put("1kye", "funky_value");

            sut.Get("ke1y");
            sut.Get("key1");

            sut.Put("key2", "spicy_value");

            Assert.Null(sut.Get("k1ey"));
            Assert.True(sut.Get("key2") == "spicy_value");
        }

        [Fact]
        public void Key_Hits_Correct()
        {
            var sut = new NativeCache<string>(5);

            sut.Put("key0", "nice_value");
            sut.Put("key1", "greedy_value");
            sut.Put("key2", "piggy_value");

            var key0Index = Array.FindIndex(sut.slots, v => v == "key0");
            var key1Index = Array.FindIndex(sut.slots, v => v == "key1");
            var key2Index = Array.FindIndex(sut.slots, v => v == "key2");

            sut.Get("key1");
            sut.Get("key2");
            sut.Get("key2");

            Assert.True(sut.hits[key0Index] == 0);
            Assert.True(sut.hits[key1Index] == 1);
            Assert.True(sut.hits[key2Index] == 2);
        }
    }
}
