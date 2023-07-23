using AlgorithmsDataStructures;
using Xunit;

namespace School.UnitTests.ADS
{
    public class HashTableTests
    {
        [Fact]
        public void HashTable_Works_Correct()
        {
            var sut = new HashTable(19, 3);

            var emptyIndexResult = sut.Find("novalue");

            Assert.True(emptyIndexResult == -1);

            sut.Put("nicevalue");

            var realIndex = sut.Find("nicevalue");

            Assert.True(realIndex != -1);

            var collisionValue1 = "collision";
            var collisionValue2 = "conlisiol";

            sut.Put(collisionValue1);
            sut.Put(collisionValue2);

            var collissionIndex1 = sut.Find(collisionValue1);
            var collissionIndex2 = sut.Find(collisionValue2);

            Assert.True(collissionIndex1 != -1);
            Assert.True(collissionIndex2 != -1);
            Assert.True(collissionIndex1 != collissionIndex2);
        }
    }
}
