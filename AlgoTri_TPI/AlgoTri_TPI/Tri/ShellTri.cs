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
        public List<Position> _lp;
        public ShellTri()
        {
            _lp = new List<Position>();

        }
        public override void BestCase()
        {
            Values = Enumerable.Range(1, 20).ToList();
            addValuesToPos();
        }
        private void addValuesToPos()
        {
            List<int> ints = new List<int>(Values);

            _lp.Add(new Position(ints));
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
            addValuesToPos();
        }

        public override void Sort()
        {
            int[] intervalles = { 6, 4, 3, 2, 1 };
            for (int ngap = 0; ngap < 5; ngap++)
            {
                for (int i = 0; i < intervalles[ngap]; i++)
                {
                    tri_insertion(Values, intervalles[ngap], i);
                }
            }
        }

        public void tri_insertion(List<int> t, int gap, int debut) {
            int j, en_cours;
            for (int i = gap+debut; i < 20; i++)
            {
                en_cours = t[i];
                for (j = i; j >= gap && t[j-gap] > en_cours; j-=gap)
                {
                    t[j] = t[j - gap];
                }
                t[j] = en_cours;
            }
        }
        public override void WorstCase()
        {
            Values = new List<int>();
            Values.AddRange(new List<int>() { 19,6,20,8,16,15,17,5,18,7,10,12,14,2,4,3,9,11,13,1 });
            addValuesToPos();
        }

    }
}
