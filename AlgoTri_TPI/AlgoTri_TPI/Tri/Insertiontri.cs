﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTri_TPI.Tri
{
    public class Insertiontri : Tri
    {
        private List<int> values;

        public List<int> Values { get => values; private set => values = value; }

        public Insertiontri()
        {
            Random();

            Sort();
        }
        public override void Sort()
        {
            int en_cours;
            int i,j;
            for (i = 0; i < 20; i++)
            {
                en_cours = Values[i];
                for (j = i; j > 0 && Values[j-1] > en_cours; j--)
                {
                    Values[j] = Values[j - 1];
                }
                Values[j] = en_cours;
            }
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


        public override void WorstCase()
        {
            throw new NotImplementedException();
        }
    }
}
