/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est la classe abstraite de tous les tris
 Date : 19.05.2021
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI.Tri
{
    public abstract class Tri
    {

        #region Methods
        // Tri les valeurs
        public abstract void Sort();

        // Donne le meilleur des cas
        public abstract void BestCase();
        // Donne le pire des cas
        public abstract void WorstCase();
        // Donne des valeurs aléatoire
        public abstract void Random();

        #endregion
    }
}
