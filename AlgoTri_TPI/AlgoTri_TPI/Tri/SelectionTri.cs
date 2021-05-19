/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est le tri par Séléction
 Date : 19.05.2021
 */
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
        //Liste des valeurs
        private List<int> values;
        public List<int> Values { get => values; private set => values = value; }
        public List<Position> _lp;
        public SelectionTri()
        {
            _lp = new List<Position>();
        }
        /// <summary>
        /// Tri les valeurs de la liste et les ajoutes dans la liste des positions
        /// </summary>
        public override void Sort()
        {
            //Ce tri prend la valeur a l'index de l'étape en cours cherche une valeur plus petite et les inverses si c'est le cas
            int i, min, j, x;
            for (i = 0; i < Values.Count - 1; i++)
            {
                min = i;
                for (j = i + 1; j < Values.Count; j++)
                    if (Values[j] < Values[min])
                        min = j;
                if (min != i)
                {
                    x = Values[i];
                    Values[i] = Values[min];
                    Values[min] = x;
                    addValuesToPos();
                }
            }
        }
        /// <summary>
        /// Ajoute les valeurs a la liste des positions
        /// </summary>
        private void addValuesToPos()
        {
            List<int> ints = new List<int>(Values);

            _lp.Add(new Position(ints));
        }
        /// <summary>
        /// donne le meilleur des cas
        /// </summary>
        public override void BestCase()
        {
            Values = Enumerable.Range(1, 20).ToList();
            addValuesToPos();
        }
        /// <summary>
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
        /// Donne le pire des cas
        /// </summary>
        public override void WorstCase()
        {
            Values = Enumerable.Range(1, 20).Reverse().ToList();
            addValuesToPos();
        }
    }
}
