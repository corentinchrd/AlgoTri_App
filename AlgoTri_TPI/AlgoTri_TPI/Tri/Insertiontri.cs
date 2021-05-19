/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est le tri par Insertion
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
    public class Insertiontri : Tri
    {//Liste des valeurs
        private List<int> values;
        public List<int> Values { get => values; private set => values = value; }
        public List<Position> _lp;
        public Insertiontri()
        {
            _lp = new List<Position>();
        }
        /// <summary>
        /// Tri les valeurs de la liste et les ajoutes dans la liste des positions
        /// </summary>
        public override void Sort()
        {
            //ce tri prend une valeur a l'index et regarde si il est plus grand ou pas que les index précédent si oui il l'insert au bon index
            int en_cours;
            int i, j;
            for (i = 0; i < 20; i++)
            {
                en_cours = Values[i];
                for (j = i; j > 0 && Values[j - 1] > en_cours; j--)
                {
                    Values[j] = Values[j - 1];
                }
                Values[j] = en_cours;

                addValuesToPos();
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
            Values = Enumerable.Range(1, 20)     // la plage de nombres dans la collection,
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
