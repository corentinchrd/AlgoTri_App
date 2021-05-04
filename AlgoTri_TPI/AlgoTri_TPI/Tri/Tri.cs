using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI.Tri
{
    public abstract class Tri
    {

        #region Methods
        public abstract void Sort();
        public abstract void BestCase();
        public abstract void WorstCase();
        public abstract void Random();
        public abstract void NextStep();

        #endregion
    }
}
