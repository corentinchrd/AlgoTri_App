using System;
using Xunit;
using AlgoTri_TPI;
using System.Collections.Generic;

namespace TestTri
{
    public class UnitTestTriInsertion
    {
        [Fact]
        public void TestInsertion()
        {
            AlgoTri_TPI.Tri.Insertiontri Insertiontri = new AlgoTri_TPI.Tri.Insertiontri();

            Insertiontri.Sort();

            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, Insertiontri.Values);

        }
    }
}
