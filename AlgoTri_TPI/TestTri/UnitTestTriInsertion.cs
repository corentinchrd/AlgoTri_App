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
            Insertiontri.Random();
            Insertiontri.Sort();


            AlgoTri_TPI.Tri.Insertiontri InsertiontriBest = new AlgoTri_TPI.Tri.Insertiontri();
            AlgoTri_TPI.Tri.Insertiontri InsertiontriWorst = new AlgoTri_TPI.Tri.Insertiontri();

            Insertiontri.Random();
            Insertiontri.Sort();

            InsertiontriBest.BestCase();
            InsertiontriWorst.WorstCase();

            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, Insertiontri.Values);

            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, InsertiontriBest.Values);
            Assert.Equal(new List<int> { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, InsertiontriWorst.Values);

        }
    }
}
