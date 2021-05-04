using System;
using Xunit;
using AlgoTri_TPI;
using System.Collections.Generic;

namespace TestTri
{
    public class UnitTestTriPeigne
    {
        [Fact]
        public void TestPeigne()
        {
            AlgoTri_TPI.Tri.PeigneTri PeigneTri = new AlgoTri_TPI.Tri.PeigneTri();

            PeigneTri.Sort();

            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, PeigneTri.Values);

        }
    }
}
