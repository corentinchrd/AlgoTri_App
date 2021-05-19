/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est le tri a Peigne
 Date : 19.05.2021
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;

namespace AlgoTri_TPI.Tri
{
    public class PeigneTri : Tri
    {
        private List<int> values;
        private int intervalle = 20;
        const int VALEUR_MAX = 20;
        public List<int> Values { get => values; private set => values = value; }
        public int Intervalle { get => intervalle; private set => intervalle = value; }

        public List<Position> _lp;
        
        public PeigneTri()
        {
            _lp = new List<Position>();

        }
        /// <summary>
        /// donne le meilleur des cas
        /// </summary>
        public override void BestCase()
        {
            Values = Enumerable.Range(1, VALEUR_MAX).ToList();
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
        /// donne le meilleur des cas
        /// </summary>
        public override void Random()
        {
            Values = Enumerable.Range(1, VALEUR_MAX)     // la plage de nombres dans ta collection,
                  .OrderBy(x => Guid.NewGuid())   // ordonné par rapport à un guid,
                  .ToList(); 
            addValuesToPos();
        }
        /// <summary>
        /// Tri les valeurs de la liste et les ajoutes dans la liste des positions
        /// </summary>
        public override void Sort()
        {
            // Ce tri prendre une valeur d'intervalle ensuite séléctionne une valeur a un index et a un index + l'intervalle regarde si ils sont plus petit ou plus grand et inverse
            Intervalle = 20;
            bool permutation = true;
            int en_cours;

            while ((permutation) || (Intervalle > 1))
            {
                permutation = false;
                Intervalle = (int)(Intervalle / 1.3);
                if (Intervalle < 1) Intervalle = 1;
                for (en_cours = 0; en_cours < 20 - Intervalle; en_cours++)
                {
                    if (Values[en_cours] > Values[en_cours + Intervalle])
                    {
                        permutation = true;
                        // on echange les deux elements
                        int temp = Values[en_cours];
                        Values[en_cours] = Values[en_cours + Intervalle];
                        Values[en_cours + Intervalle] = temp;
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
            Values = new List<int>();
            Values.AddRange(new List<int>() { 18, 2, 10, 19, 13, 3, 11, 20, 6, 12, 4, 7, 8, 17, 15, 14, 1, 5, 16, 9 });
        }
    }
}
