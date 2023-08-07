
using AlgorithmsDataStructures;
using System.Diagnostics;
using Xunit;

namespace School.UnitTests.ADS
{
    public class PowerSetTests
    {
        [Fact]
        public void PowerSet_Works()
        {
            var sut = new PowerSet<string>();

            sut.Put("abra");

            Assert.True(sut.Get("abra"));

            sut.Put("abra");

            Assert.True(sut.Size() == 1);

            sut.Remove("abra");

            Assert.True(sut.Size() == 0);

            Assert.False(sut.Get("abra"));
        }

        [Fact]
        public void Union_Works_Correct()
        {
            var set1 = GenerateDataSet(5);
            var set2 = GenerateDataSet(5, 5);

            var sut = set1.Union(set2);

            Assert.True(sut.Size() == 10);
        }

        [Fact]
        public void Intersection_Works_Correct()
        {
            var set1 = GenerateDataSet(5);
            var set2 = GenerateDataSet(5, 1);

            var sut = set1.Intersection(set2);

            Assert.True(sut.Size() == 4);
            Assert.True(sut.Get("1"));
            Assert.False(sut.Get("0"));
        }

        [Fact]
        public void Intersection_Works_Correct_When_Empty_Set_Expetced()
        {
            var set1 = GenerateDataSet(5);
            var set2 = GenerateDataSet(5, 5);

            var sut = set1.Intersection(set2);

            Assert.True(sut.Size() == 0);
        }

        [Fact]
        public void Difference_Works_Correct_When_Empty_Set_Expetced()
        {
            var set1 = GenerateDataSet(5);
            var set2 = GenerateDataSet(5);

            var sut = set1.Difference(set2);

            Assert.True(sut.Size() == 0);
        }

        [Fact]
        public void Difference_Works_Correct()
        {
            var set1 = GenerateDataSet(5);
            var set2 = GenerateDataSet(5, 1);

            var sut = set1.Difference(set2);

            Assert.True(sut.Get("0"));
        }

        [Fact]
        public void IsSubset_Returns_True_When_Contains_All_Elemetns()
        {
            var set1 = GenerateDataSet(5);
            var set2 = GenerateDataSet(3);

            var result = set2.IsSubset(set1);

            Assert.True(result);
        }

        [Fact]
        public void IsSubset_Returns_False_When_Mismatch_Exists()
        {
            var set1 = GenerateDataSet(5);
            var set2 = GenerateDataSet(5, 1);

            var result = set2.IsSubset(set1);

            Assert.False(result);
        }

        [Fact]
        public void Intersection_Works_Fast()
        {
            var set1 = GenerateDataSet(8000);
            var set2 = GenerateDataSet(8000);

            var sp = new Stopwatch();
            sp.Start();
            set1.Intersection(set2);
            sp.Stop();

            Assert.True(sp.ElapsedMilliseconds < 3 * 1000);
        }

        private PowerSet<string> GenerateDataSet(int size, int seed = 0)
        {
            var set = new PowerSet<string>();
            for (var i = 0; i < size; i++)
            {
                var element = seed + i;
                set.Put(element.ToString());
            }

            return set;
        }
    }
}
