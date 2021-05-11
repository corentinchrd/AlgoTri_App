using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgoTri_TPI.States;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace AlgoTri_TPI.Tri
{
    public class BulleTri : Tri
    {
        private List<int> values;
        public List<int> Values { get => values; private set => values = value; }

        private List<Position> _lp;
        public List<Position> Lp { get => _lp; set => _lp = value; }
        public BulleTri()
        {
            Lp = new List<Position>();
        }
        public override void BestCase()
        {
            Values = Enumerable.Range(1, 20).ToList();
            addValuesToPos();
        }

        public override void NextStep()
        {
            throw new NotImplementedException();
        }
        private void addValuesToPos()
        {
            List<int> ints = new List<int>(Values);

            Lp.Add(new Position(ints));
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
                    addValuesToPos();
                }
            }
        }

        public override void WorstCase()
        {
            Values = Enumerable.Range(1, 20).Reverse().ToList();
            addValuesToPos();
        }
        public bool isSort()
        {
            for (int i = 0; i < Values.Count(); i++)
            {
                if (Values[i] != i + 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
