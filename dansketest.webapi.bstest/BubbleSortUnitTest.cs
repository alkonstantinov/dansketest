using dansketest.webapi.bs.Sort;
using System;
using Xunit;

namespace dansketest.webapi.bstest
{
    public class BubbleSortUnitTest
    {
        [Fact]
        public void Test1()
        {
            var obj = new BubbleSorter(" ,");
            var arr = obj.Sort("1, 4, 10, 2  7");
            var correct = new int[] { 1, 2, 4, 7, 10 };
            Assert.Equal(correct.Length, arr.Length);
            for (int i = 0; i < correct.Length; i++)
                Assert.Equal(correct[i], arr[i]);
        }
    }
}
