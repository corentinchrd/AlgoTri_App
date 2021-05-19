/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est le tri a Shell
 Date : 19.05.2021
 */
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
        /// <summary>
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
        /// Tri les valeurs de la liste et les ajoutes dans la liste des positions
        /// </summary>
        public override void Sort()
        {
            //ce tri prend des valeurs a intervalle créée une nouvelle liste et utilise le tri par insertion pour trier cette dernière liste
            int[] intervalles = { 6, 4, 3, 2, 1 };
            for (int ngap = 0; ngap < 5; ngap++)
            {
                for (int i = 0; i < intervalles[ngap]; i++)
                {
                    tri_insertion(Values, intervalles[ngap], i);
                }
            }
        }
        /// <summary>
        /// Tri les valeurs par insertion
        /// </summary>
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
        /// <summary>
        /// Donne le pire des cas
        /// </summary>
        public override void WorstCase()
        {
            Values = new List<int>();
            Values.AddRange(new List<int>() { 19,6,20,8,16,15,17,5,18,7,10,12,14,2,4,3,9,11,13,1 });
            addValuesToPos();
        }

    }
}
