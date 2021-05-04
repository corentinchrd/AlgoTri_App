using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgoTri_TPI.Tri
{
    public class BulleTri : Tri
    {
        private List<int> values;

        public List<int> Values { get => values; private set => values = value; }
        public BulleTri()
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
            int passage = 0;
            bool permutation = true;
            int en_cours;

            while (permutation) {
                permutation = false;
                passage++;
                for (en_cours = 0; en_cours < 20-passage; en_cours++)
                {
                    if (Values[en_cours] > Values[en_cours + 1]) {
                        permutation = true;
                        int temp = Values[en_cours];
                        Values[en_cours] = Values[en_cours + 1];
                        Values[en_cours +1] = temp;
                    }
                }
            }
        }

        public override void WorstCase()
        {
            throw new NotImplementedException();
        }
    }
}
