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
    class AfficherPeigne : AffichageTri
    {
        List<RectangleValue> rectangleValues;
        Texture2D rectangleSprite;
        SpriteFont font;
        List<Color> _colors;
        List<Position> positions;
        PeigneState peigneState;
        public List<int> gapPeigne = new List<int>() { 15, 11, 8, 6, 4, 3, 2, 1 };
        public int currentState = 1;
        public int compteur = 0;
        private int Iteration = 0;

        public int Iteration1 { get => Iteration; private set => Iteration = value; }

        public AfficherPeigne(Texture2D rS, SpriteFont f, List<Position> p, PeigneState ist)
        {
            rectangleValues = new List<RectangleValue>();
            rectangleSprite = rS;
            font = f;
            positions = p;
            peigneState = ist;
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
        public override List<RectangleValue> afficherList()
        {
            for (int i = 0; i < 20; i++)
            {
                RectangleValue rt = new RectangleValue(rectangleSprite, new Vector2(peigneState.tableauPosition[i], 350), font, positions[0].position[i], _colors[i], i);
                rectangleValues.Add(rt);
            }
            rectangleValues[0].IsSelected = true;
            return rectangleValues;
        }

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

        public override List<RectangleValue> AfficherNextPos()
        {
            if (currentState != peigneState.AllPosition.Count() - 1)
            {
                currentState++;
            }
            List<RectangleValue> tmpList = rectangleValues;
            List<int> old = positions[currentState - 1].position;
            List<int> newPos = positions[currentState].position;

            Dictionary<int, int> kvp = compareTwoList(old, newPos);

            foreach (var item in kvp)
            {
                rectangleValues.Find(x => x.Value == item.Value).PositionIndex = item.Key;
                rectangleValues.Find(x => x.Value == item.Value).UpdatePos(peigneState.tableauPosition[item.Key]);

            }
            for (int i = 0; i < rectangleValues.Count(); i++)
            {
                if (i == currentState)
                    rectangleValues[i].IsSelected = true;
                else
                    rectangleValues[i].IsSelected = false;
            }
            return rectangleValues;
        }

        public override List<RectangleValue> AfficherNextPosAndState()
        {
            int value1 = rectangleValues.Find(x => x.PositionIndex == compteur).Value;
            int value2 = rectangleValues.Find(x => x.PositionIndex == compteur + gapPeigne[Iteration1]).Value;
            int posIndex1 = rectangleValues.Find(x => x.PositionIndex == compteur).PositionIndex;
            int posIndex2 = rectangleValues.Find(x => x.PositionIndex == compteur + gapPeigne[Iteration1]).PositionIndex;

            if (peigneState.etape == 7)
            {
                rectangleValues.Find(x=> x.PositionIndex == compteur).moveDown();
                rectangleValues.Find(x => x.PositionIndex == compteur + gapPeigne[Iteration1]).moveDown();
            }
            else if (peigneState.etape == 8)
            {
                if (value1 > value2)
                {

                    rectangleValues.Find(x => x.Value == value1).PositionIndex = posIndex2;
                    rectangleValues.Find(x => x.Value == value2).PositionIndex = posIndex1;

                    rectangleValues.Find(x => x.Value == value1).UpdatePos(peigneState.tableauPosition[rectangleValues.Find(x => x.Value == value1).PositionIndex]);
                    rectangleValues.Find(x => x.Value == value2).UpdatePos(peigneState.tableauPosition[rectangleValues.Find(x => x.Value == value2).PositionIndex]);
                }
            }
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
