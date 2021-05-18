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
    class AfficherShell : AffichageTri
    {
        List<RectangleValue> rectangleValues;
        Texture2D rectangleSprite;
        SpriteFont font;
        List<Color> _colors;
        List<Position> positions;
        ShellState shellState;
        public int currentState = 1;
        public int compteur = 0;
        private int Iteration = 0;
        private int[] gap = { 6, 4, 3, 2, 1 };
        int intervalle;

        public int Iteration1 { get => Iteration; private set => Iteration = value; }

        public AfficherShell(Texture2D rS, SpriteFont f, List<Position> p, ShellState ist)
        {
            rectangleValues = new List<RectangleValue>();
            rectangleSprite = rS;
            font = f;
            positions = p;
            shellState = ist;
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
                RectangleValue rt = new RectangleValue(rectangleSprite, new Vector2(shellState.tableauPosition[i], 250), font, positions[0].position[i], _colors[i], i);
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
            if (currentState != shellState.AllPosition.Count() - 1)
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
                rectangleValues.Find(x => x.Value == item.Value).UpdatePos(shellState.tableauPosition[item.Key]);

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
            intervalle = 6;
            if (shellState.etape == 6)
            {
                switch (intervalle)
                {
                    case 6:
                        for (int i = 0; i < 4; i++)
                        {
                            if (i == 3)
                            {
                                for (int j = 18; j < 20; j++)
                                {
                                    if (j == 18)
                                        rectangleValues.Find(x => x.PositionIndex == j).moveDownMultiple(0);
                                    else
                                        rectangleValues.Find(x => x.PositionIndex == j).moveDownMultiple(1);
                                }
                            }
                            if (i == 3)
                            {
                                for (int j = 18; j < 20; j++)
                                {
                                    if (j == 18)
                                        rectangleValues.Find(x => x.PositionIndex == j).moveDownMultiple(0);
                                    else
                                        rectangleValues.Find(x => x.PositionIndex == j).moveDownMultiple(1);
                                }
                            }
                            else if (i == 0)
                            {
                                for (int j = 0; j < 6; j++)
                                {

                                    rectangleValues.Find(x => x.PositionIndex == j).moveDownMultiple(j);
                                }
                            }
                            else
                            {
                                for (int j = 0; j < 6; j++)
                                {

                                    rectangleValues.Find(x => x.PositionIndex == j + intervalle * i).moveDownMultiple(j);
                                }
                            }

                        }
                        break;
                    case 4:
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                rectangleValues.Find(x => x.PositionIndex == j + intervalle * i).moveDownMultiple(j);
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 6)
                            {
                                rectangleValues.Find(x => x.PositionIndex == 19).moveDownMultiple(1);
                            }
                            else
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    rectangleValues.Find(x => x.PositionIndex == j + intervalle * i).moveDownMultiple(j);
                                }
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < 20; i++)
                        {
                            if (i % 2 != 0)
                            {
                                rectangleValues.Find(x => x.PositionIndex == i).moveDown();
                            }
                        }
                        break;
                }

            }
            else if (shellState.etape == 7) {
                foreach (RectangleValue item in rectangleValues)
                {
                    item.moveOriginalPos();
                }
            }
            else if (shellState.etape == 1)
            {

            }
            return rectangleValues;
        }
    }
}
