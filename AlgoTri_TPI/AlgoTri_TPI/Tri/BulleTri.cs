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
        public List<Position> _lp;
        public BulleTri()
        {
            _lp = new List<Position>();
        }/// <summary>
         /// donne le meilleur des cas
         /// </summary>
        public override void BestCase()
        {
            Values = Enumerable.Range(1, 20).ToList();
            addValuesToPos();
        }
        /// <summary>
        /// Ajoute les valeurs a la liste des positions
        /// </summary>
        private void addValuesToPos()
        {
            List<int> ints = new List<int>(Values);

            _lp.Add(new Position(ints));
        }/// <summary>
         /// Donne des valeurs aléatoire et les ajoute a la position
         /// </summary>
        public override void Random()
        {
            Values = Enumerable.Range(1, 20)     // la plage de nombres dans ta collection,
               .OrderBy(x => Guid.NewGuid())   // ordonné par rapport à un guid,
               .ToList();

            addValuesToPos();
        }
        /// <summary>
        /// Tri les valeurs de la liste et les ajoutes dans la liste des positions
        /// </summary>
        public override void Sort()
        {
            //ce tri parcours le tableau regarde si l'index est plus grand que l'index + 1 inverse si il est necéssaire et faire ca jusqu'a ce que le talbeau est trier
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
        /// <summary>
        /// Donne le pire des cas
        /// </summary>
        public override void WorstCase()
        {
            Values = Enumerable.Range(1, 20).Reverse().ToList();
            addValuesToPos();
        }
    }
}
