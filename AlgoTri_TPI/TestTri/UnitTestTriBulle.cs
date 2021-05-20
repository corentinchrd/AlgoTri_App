using System;
using Xunit;
using AlgoTri_TPI;
using System.Collections.Generic;

namespace TestTri
{
    public class UnitTestTriBulle
    {
        [Fact]
        public void TestBulle()
        {
            AlgoTri_TPI.Tri.BulleTri bulleTri = new AlgoTri_TPI.Tri.BulleTri();

            AlgoTri_TPI.Tri.BulleTri bulleTriBest = new AlgoTri_TPI.Tri.BulleTri();
            AlgoTri_TPI.Tri.BulleTri bulleTriWorst = new AlgoTri_TPI.Tri.BulleTri();

            bulleTri.Random();
            bulleTri.Sort();

            bulleTriBest.BestCase();
            bulleTriWorst.WorstCase();

            Assert.Equal(new List<int> { 1, 2,3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, bulleTri.Values);

            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, bulleTriBest.Values);
            Assert.Equal(new List<int> { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, bulleTriWorst.Values);

        }
    }
}
