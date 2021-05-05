using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;

namespace AlgoTri_TPI.Tri
{
    public class ShellTri : Tri
    {
        private List<int> values;

        public List<int> Values { get => values; private set => values = value; }
        public ShellTri()
        {
            Random();

        }
        public override void BestCase()
        {
            throw new NotImplementedException();
        }

        public override void NextStep()
        {
            throw new NotImplementedException();
        }

        public override void Random()
        {
            Values = Enumerable.Range(1, 20)     // la plage de nombres dans ta collection,
                     .OrderBy(x => Guid.NewGuid())   // ordonné par rapport à un guid,
                     .ToList();
        }

        public override void Sort()
        {
            int n = Values.Count;
            int h = 1;

            while (h < (n >> 1))
            {
                h = (h << 1) + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    int k = i - h;
                    for (int j = i; j >= h && Values[j].CompareTo(Values[k]) < 0; k -= h)
                    {
                        int temp = Values[j];
                        Values[j] = Values[k];
                        Values[k] = temp;
                        j = k;
                    }
                }
                h >>= 1;
            }
        }


        public override void WorstCase()
        {
            throw new NotImplementedException();
        }

    }
}
