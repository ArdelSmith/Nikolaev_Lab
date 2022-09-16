/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrimSort
{
    [TestFixture()]
    class TimSortTest
    {
        [SetUp()]
        public void SetUp()
        {

        }
        [TearDown()]
        public void TearDown()
        {
        }

        [Test()]
        public void SortTest()
        {
            int[] seed = { 5, 7, 8, 10, 324, 888, 9 };
            var checks = new List<int>(seed);

            checks.Sort();
            TimSort.TimSort<int>.sort(seed, new Comparers.ComparerInt());
            Assert.AreEqual(checks.ToArray(), seed);
        }
    }


}
/*/