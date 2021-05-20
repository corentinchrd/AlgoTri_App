/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script contient permet d'envoyer a la vue les éléments à afficher pour le tri a peigne
 Date : 19.05.2021
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; // Permet de trouver la valeur d'un élément dans un tableau
using AlgoTri_TPI.States;

namespace AlgoTri_TPI.Affichage
{
    class AfficherPeigne : AffichageTri
    {
        List<RectangleValue> rectangleValues;
        Texture2D rectangleSprite;
        SpriteFont font;
        List<Color> _colors;
        List<Position> positions;
        PeigneState peigneState;
        public List<int> gapPeigne = new List<int>() { 15, 11, 8, 6, 4, 3, 2, 1 }; //Liste des ecartements a prendre entre 2 valeurs
        public int currentState = 1; //Etape dans le tri
        public int compteur = 0; //Nombre d'étape dans le tri au total
        public int nombreDeplacement = 0;
        private int Iteration = 0; //Nombre d'iteration pour definir le gap

        public int Iteration1 { get => Iteration; private set => Iteration = value; }

        public AfficherPeigne(Texture2D rS, SpriteFont f, List<Position> p, PeigneState ist)
        {
            rectangleValues = new List<RectangleValue>();
            rectangleSprite = rS;
            font = f;
            positions = p;
            peigneState = ist;
            //Liste des couleurs pour avoir des couleurs distincte
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
            // Ajoute la première étape du tri avec les valeurs sous forme de rectangleValue
            for (int i = 0; i < 20; i++)
            {
                RectangleValue rt = new RectangleValue(rectangleSprite, new Vector2(peigneState.tableauPosition[i], 350), font, positions[0].position[i], _colors[i], i);
                rectangleValues.Add(rt);
            }
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
            //La fonction .Find() utilise du Linq pour trouver la valeur voulue
            int value1 = rectangleValues.Find(x => x.PositionIndex == compteur).Value;
            int value2 = rectangleValues.Find(x => x.PositionIndex == compteur + gapPeigne[Iteration1]).Value;
            int posIndex1 = rectangleValues.Find(x => x.PositionIndex == compteur).PositionIndex;
            int posIndex2 = rectangleValues.Find(x => x.PositionIndex == compteur + gapPeigne[Iteration1]).PositionIndex;

            // Afficher les 2 valeurs qui vont être traitée
            if (peigneState.etape == 7)
            {
                rectangleValues.Find(x=> x.PositionIndex == compteur).moveDown();
                rectangleValues.Find(x => x.PositionIndex == compteur + gapPeigne[Iteration1]).moveDown();
            }
            else if (peigneState.etape == 8)
            {
                //si la valeur est plus grand intervertir les 2 valeurs grace au tableau de positions 
                if (value1 > value2)
                {

                    rectangleValues.Find(x => x.Value == value1).PositionIndex = posIndex2;
                    rectangleValues.Find(x => x.Value == value2).PositionIndex = posIndex1;

                    rectangleValues.Find(x => x.Value == value1).UpdatePos(peigneState.tableauPosition[rectangleValues.Find(x => x.Value == value1).PositionIndex]);
                    rectangleValues.Find(x => x.Value == value2).UpdatePos(peigneState.tableauPosition[rectangleValues.Find(x => x.Value == value2).PositionIndex]);
                    nombreDeplacement++;
                }
            }
            // Faire remonter les valeurs sur la meme ligne que les autres
            else if (peigneState.etape == 9)
            {
                rectangleValues.Find(x => x.PositionIndex == compteur).moveUp();
                rectangleValues.Find(x => x.PositionIndex == compteur + gapPeigne[Iteration1]).moveUp();
                if (compteur + 1 + gapPeigne[Iteration1] != 20)
                    compteur++;
                else {
                    compteur = 0;
                    Iteration1++;
                }
            }
            return rectangleValues;
        }
    }
}
