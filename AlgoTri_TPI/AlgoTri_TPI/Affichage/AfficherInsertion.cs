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
    class AfficherInsertion : AffichageTri
    {
        List<RectangleValue> rectangleValues;
        Texture2D rectangleSprite;
        SpriteFont font;
        List<Color> _colors;
        List<Position> positions;
        InsertionState insertionState;
        bool move = false;

        public int currentState = 0;
        public AfficherInsertion(Texture2D rS, SpriteFont f, List<Position> p, InsertionState ist)
        {
            rectangleValues = new List<RectangleValue>();
            rectangleSprite = rS;
            font = f;
            positions = p;
            insertionState = ist;
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
                RectangleValue rt = new RectangleValue(rectangleSprite, new Vector2(insertionState.tableauPosition[i], 350), font, positions[0].position[i], _colors[i], i);
                rectangleValues.Add(rt);
            }
            return rectangleValues;
        }
        //public List<RectangleValue> afficherEtapeSuivant()
        //{ 
        //    insertionState._rectangles = 
        //}
        public override List<int> GetValues()
        {
            //List<int> tmpList = new List<int>();
            //foreach (RectangleValue item in rectangleValues)
            //{
            //    tmpList.Add(item.Value);
            //}
            //values = tmpList;
            return new List<int>();
        }

        //public override void switchTwoValues(Dictionary<int,int> d)
        //{
        //    foreach (var item in d)
        //    {
        //        if (item.Key == 0)
        //        {
        //            _rectangles.Find(x => x.Value == item.Value).MoveTo(_rectangles[0].StartPos);
        //            tuples.Add(new Tuple<RectangleValue, Vector2>(_rectangles.Find(x => x.Value == item.Value), _rectangles[0].StartPos));
        //        }
        //        else
        //        {
        //            _rectangles.Find(x => x.Value == item.Value).MoveTo(_rectangles[item.Key].StartPos);
        //            tuples.Add(new Tuple<RectangleValue, Vector2>(_rectangles.Find(x => x.Value == item.Value), _rectangles[item.Key].StartPos));
        //        }
        //    }

        //    move = false;
        //}

        public Dictionary<int, int> compareTwoList(List<int> a, List<int> b)
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
        public List<RectangleValue> AfficherNextPos()
        {
            if (currentState != 20)
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
                rectangleValues.Find(x => x.Value == item.Value).UpdatePos(insertionState.tableauPosition[item.Key]);

            }
            //foreach (RectangleValue item in rectangleValues)
            //{
            //    item.UpdatePos(insertionState.tableauPosition.Find(x => x == item.Position));
            //}
            return rectangleValues;
        }
        public List<RectangleValue> AfficherPrevPos()
        {
            if (currentState != 0)
            {
                currentState--;
            }
            List<RectangleValue> tmpList = rectangleValues;
            List<int> old = positions[currentState + 1].position;
            List<int> newPos = positions[currentState].position;

            Dictionary<int, int> kvp = compareTwoList(old, newPos);

            foreach (var item in kvp)
            {
                rectangleValues.Find(x => x.Value == item.Value).PositionIndex = item.Key;
                rectangleValues.Find(x => x.Value == item.Value).UpdatePos(insertionState.tableauPosition[item.Key]);

            }
            return rectangleValues;
        }
    }
}
