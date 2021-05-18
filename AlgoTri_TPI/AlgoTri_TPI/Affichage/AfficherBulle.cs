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
    class AfficherBulle : AffichageTri
    {
        List<RectangleValue> rectangleValues;
        Texture2D rectangleSprite;
        SpriteFont font;
        List<Color> _colors;
        List<Position> positions;
        BulleState bulleState;

        public int currentState = 1;
        public int compteur = 0;
        private int Iteration = 0;
        public AfficherBulle(Texture2D rS, SpriteFont f, List<Position> p, BulleState ist)
        {
            rectangleValues = new List<RectangleValue>();
            rectangleSprite = rS;
            font = f;
            positions = p;
            bulleState = ist;
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
                RectangleValue rt = new RectangleValue(rectangleSprite, new Vector2(bulleState.tableauPosition[i], 350), font, positions[0].position[i], _colors[i], i);
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
            if (currentState != bulleState.AllPosition.Count() - 1)
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
                rectangleValues.Find(x => x.Value == item.Value).UpdatePos(bulleState.tableauPosition[item.Key]);

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
            List<int> old = positions[currentState - 1].position;
            List<int> newPos = positions[currentState].position;

            Dictionary<int, int> kvp = compareTwoList(old, newPos);

            if (bulleState.etape == 5)
            {
                rectangleValues.Find(x => x.PositionIndex == compteur).moveDown();
                rectangleValues.Find(x => x.PositionIndex == compteur + 1).moveDown();

            }
            else if (bulleState.etape == 6)
            {
                foreach (var item in kvp)
                {
                    rectangleValues.Find(x => x.Value == item.Value).PositionIndex = item.Key;
                    rectangleValues.Find(x => x.Value == item.Value).UpdatePos(bulleState.tableauPosition[item.Key]);
                }
            }
            else if (bulleState.etape == 9)
            {

                rectangleValues.Find(x => x.PositionIndex == compteur).moveUp();
                rectangleValues.Find(x => x.PositionIndex == compteur + 1).moveUp();

            }
            else if (bulleState.etape == 10)
            {
                if (compteur + 1 != 19 - Iteration)
                    compteur++;
                else { 
                    compteur = 0;
                    Iteration++;
                }
            }
            return rectangleValues;
        }
    }
}
