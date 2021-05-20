using System;
using Xunit;
using AlgoTri_TPI;
using System.Collections.Generic;

namespace TestTri
{
    public class UnitTestTriSelection
    {
        [Fact]
        public void TestSelection()
        {
            AlgoTri_TPI.Tri.SelectionTri selectionTri = new AlgoTri_TPI.Tri.SelectionTri();
            selectionTri.Random();
            selectionTri.Sort();

            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, selectionTri.Values);
            AlgoTri_TPI.Tri.SelectionTri SelectionTriBest = new AlgoTri_TPI.Tri.SelectionTri();
            AlgoTri_TPI.Tri.SelectionTri SelectionTriWorst = new AlgoTri_TPI.Tri.SelectionTri();

            SelectionTriBest.BestCase();
            SelectionTriWorst.WorstCase();


            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, SelectionTriBest.Values);
            Assert.Equal(new List<int> { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, SelectionTriWorst.Values);

        }
    }
}
