using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgoTri_TPI.Tri
{
    public class PeigneTri : Tri
    {
        private List<int> values;

        public List<int> Values { get => values; private set => values = value; }
        public PeigneTri()
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
            int intervalle = 20;
            bool permutation = true;
            int en_cours;

            while ((permutation) || (intervalle > 1))
            {
                permutation = false;
                intervalle = (int)(intervalle / 1.3);
                if (intervalle < 1) intervalle = 1;
                for (en_cours = 0; en_cours < 20 - intervalle; en_cours++)
                {
                    if (Values[en_cours] > Values[en_cours + intervalle])
                    {
                        permutation = true;
                        // on echange les deux elements
                        int temp = Values[en_cours];
                        Values[en_cours] = Values[en_cours + intervalle];
                        Values[en_cours + intervalle] = temp;
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
