using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;

namespace AlgoTri_TPI.Tri
{
    public class SelectionTri : Tri
    {
        private List<RectangleValue> rectanglesvalues;
        private List<int> Values;
        public List<RectangleValue> Rectanglesvalues { get => rectanglesvalues; private set => rectanglesvalues = value; }
        public List<int> Values1 { get => Values; set => Values = value; }

        public SelectionTri()
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
            Values1 = Enumerable.Range(1, 20)     // la plage de nombres dans ta collection,
                     .OrderBy(x => Guid.NewGuid())   // ordonné par rapport à un guid,
                     .ToList();
        }

        public override void Sort()
        {
            int min, temp;
            for (int i = 0; i < 20 - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < 20; j++)
                    if (Values1[j] < Values1[min])
                        min = j;
                if (min != i)
                {
                    //échanger t[i] et t[min]
                    temp = Values1[i];
                    Values1[i] = Values1[min];
                    Values1[min] = temp;
                }
            }
        }

        public override void WorstCase()
        {
            throw new NotImplementedException();
        }
    }
}
