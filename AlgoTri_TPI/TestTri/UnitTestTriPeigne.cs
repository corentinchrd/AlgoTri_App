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
            PeigneTri.Random();
            PeigneTri.Sort();

            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, PeigneTri.Values);
            


            AlgoTri_TPI.Tri.PeigneTri PeigneTriBest = new AlgoTri_TPI.Tri.PeigneTri();
            AlgoTri_TPI.Tri.PeigneTri PeigneTriWorst = new AlgoTri_TPI.Tri.PeigneTri();

            PeigneTriBest.BestCase();
            PeigneTriWorst.WorstCase();


            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, PeigneTriBest.Values);
            Assert.Equal(new List<int> { 18, 2, 10, 19, 13, 3, 11, 20, 6, 12, 4, 7, 8, 17, 15, 14, 1, 5, 16, 9 }, PeigneTriWorst.Values);

        }
    }
}
