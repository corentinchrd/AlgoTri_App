using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI
{
    public abstract class AffichageTri
    {
        public abstract List<RectangleValue> afficherList();
        public abstract List<RectangleValue> switchTwoValues(List<RectangleValue> rectangleValues, int v1, int v2);
        public abstract List<int> GetValues();
    }
}
