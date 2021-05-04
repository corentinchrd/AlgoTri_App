using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgoTri_TPI.Tri
{
    public class SelectionTri : Tri
    {
        private List<int> values;

        public List<int> Values { get => values; private set => values = value; }
        public SelectionTri()
        {
            Random();

            Sort();
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
            int min, temp;
            for (int i = 0; i < 20 - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < 20; j++)
                    if (Values[j] < Values[min])
                        min = j;
                if (min != i)
                {
                    //échanger t[i] et t[min]
                    temp = Values[i];
                    Values[i] = Values[min];
                    Values[min] = temp;
                }
            }
        }

        public override void WorstCase()
        {
            throw new NotImplementedException();
        }
    }
}
