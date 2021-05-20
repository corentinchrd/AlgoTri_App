/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script contient permet d'envoyer a la vue les éléments à afficher pour le tri séléction
 Date : 19.05.2021
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AlgoTri_TPI.States;

namespace AlgoTri_TPI.Affichage
{
    class AfficherSelection : AffichageTri
    {
        List<RectangleValue> rectangleValues;
        Texture2D rectangleSprite;
        SpriteFont font;
        List<Color> _colors;
        List<Position> positions;
        SelectionState selectionState;

        public int currentState = 1;
        public int compteur = 0;
        private int Iteration = 0;
        public int nombreDeplacement = 0;

        public AfficherSelection(Texture2D rS, SpriteFont f, List<Position> p, SelectionState ist)
        {
            rectangleValues = new List<RectangleValue>();
            rectangleSprite = rS;
            font = f;
            positions = p;
            selectionState = ist;
            // Liste des couleurs
            #region Colors 
            _colors = new List<Color>();

            _colors.Add(Color.Red);
            _colors.Add(Color.Green);
            _colors.Add(Color.Blue);
            _colors.Add(Color.Yellow);
            _colors.Add(Color.YellowGreen);
            _colors.Add(Color.GreenYellow);
            _colors.Add(Color.Black);
            _colors.Add(Color.White);
            _colors.Add(Color.Gold);
            _colors.Add(Color.LightCoral);
            _colors.Add(Color.Pink);
            _colors.Add(Color.Coral);
            _colors.Add(Color.Purple);
            _colors.Add(Color.DarkRed);
            _colors.Add(Color.Brown);
            _colors.Add(Color.DeepPink);
            _colors.Add(Color.DarkBlue);
            _colors.Add(Color.Bisque);
            _colors.Add(Color.IndianRed);
            _colors.Add(Color.Linen);
            #endregion 
        }
        /// <summary>
        /// Retourne la liste de rectangle à afficher
        /// </summary>
        /// <returns></returns>
        public override List<RectangleValue> afficherList()
        {
            for (int i = 0; i < 20; i++)
            {
                RectangleValue rt = new RectangleValue(rectangleSprite, new Vector2(selectionState.tableauPosition[i], 350), font, positions[0].position[i], _colors[i], i);
                rectangleValues.Add(rt);
            }
            rectangleValues[0].IsSelected = true;
            return rectangleValues;
        }
        /// <summary>
        /// Permet de comparer la list a et la list b et de renvoyer un dictionnaire avec les différence a l'index
        /// </summary>
        /// <param name="a">Liste 1</param>
        /// <param name="b">Liste 2</param>
        /// <returns></returns>
        public override Dictionary<int, int> compareTwoList(List<int> a, List<int> b)
        {
            var differences = new Dictionary<int, int>();

            for (var j = 0; j < a.Count; j++)
            {
                if (b[j] != a[j])
                {
                    differences.Add(j, b[j]);
                }
            }
            return differences;
        }
         /// <summary>
         /// Retourne une List de RectangleValue avec des étapes intermediaire
         /// </summary>
         /// <returns>List<RectangleValues></returns>
        public override List<RectangleValue> AfficherNextPosAndState()
        {
            List<int> old = positions[currentState - 1].position;
            List<int> newPos = positions[currentState].position;

            Dictionary<int, int> kvp = compareTwoList(old, newPos);

            // Afficher toute les différence entre l'étape en cours et l'étape suivante
            if (selectionState.etape == 1)
            {
                foreach (var item in kvp)
                {
                    rectangleValues.Find(x => x.Value == item.Value).moveDown();
                }
            }
            // Changer la position de toutes les différence
            else if (selectionState.etape == 2)
            {
                foreach (var item in kvp)
                {
                    rectangleValues.Find(x => x.Value == item.Value).PositionIndex = item.Key;
                    rectangleValues.Find(x => x.Value == item.Value).UpdatePos(selectionState.tableauPosition[item.Key]);
                }
                if (kvp.Count != 0) {
                    nombreDeplacement++;
                }
            }
            // Faire remonter les valeurs sur la meme ligne que les autres
            else if (selectionState.etape == 3) {
                foreach (var item in kvp)
                {
                    rectangleValues.Find(x => x.Value == item.Value).moveUp();
                }
            }
            return rectangleValues;

        }
    }
}
