using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI
{
    public abstract class AffichageTri
    {
        public abstract List<RectangleValue> afficherList();
        public abstract Dictionary<int, int> compareTwoList(List<int> a, List<int> b);
        public abstract List<RectangleValue> AfficherNextPos();
        public abstract List<RectangleValue> AfficherNextPosAndState();
    }
}
