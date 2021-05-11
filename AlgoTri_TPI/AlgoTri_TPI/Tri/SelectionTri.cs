using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgoTri_TPI.States;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AlgoTri_TPI.Tri
{
    public class SelectionTri : Tri
    {
        private List<int> values;
        public List<int> Values { get => values; private set => values = value; }
        public List<Position> _lp;
        public SelectionTri()
        {
            _lp = new List<Position>();
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

        private void addValuesToPos()
        {
            List<int> ints = new List<int>(Values);

            _lp.Add(new Position(ints));
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

        public override void Random()
        {
            Values = Enumerable.Range(1, 20)     // la plage de nombres dans ta collection,
               .OrderBy(x => Guid.NewGuid())   // ordonné par rapport à un guid,
               .ToList();

            addValuesToPos();
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
