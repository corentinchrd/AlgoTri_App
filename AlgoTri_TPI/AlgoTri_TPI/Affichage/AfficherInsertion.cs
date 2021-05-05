using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI.Affichage
{
    class AfficherInsertion : AffichageTri
    {
        List<RectangleValue> rectangleValues;
        Texture2D rectangleSprite;
        SpriteFont font;
        List<Color> _colors;
        List<int> values;

        public AfficherInsertion(Texture2D rS,SpriteFont f,List<int> v)
        {
            rectangleValues = new List<RectangleValue>();
            rectangleSprite = rS;
            font = f;
            values = v;
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
        public override List<RectangleValue>  afficherList()
        {
            int space = 45;
            for (int i = 0; i < 20; i++)
            {
                RectangleValue rt = new RectangleValue(rectangleSprite, new Vector2(152f + space * i, 350), font, values[i], _colors[i]);
                rectangleValues.Add(rt);
            }
            return rectangleValues;
        }

        public override List<int> GetValues()
        {
            List<int> tmpList = new List<int>();
            foreach (RectangleValue item in rectangleValues)
            {
                tmpList.Add(item.Value);
            }
            values = tmpList;
            return tmpList;
        }

        public override List<RectangleValue> switchTwoValues(List<RectangleValue> rv,int v1,int v2)
        {
            int tmp = values[v1];


            rv[v1].MoveTo(rv[v2].StartPos);
            rv[v2].MoveTo(rv[v1].StartPos);

            values[v1] = values[v2];
            values[v2] = tmp;

            foreach (int i in values) {
                int index = rectangleValues.FindIndex((x => x.Value == i));
                rectangleValues[index].Value = i;
            }
            return rectangleValues;
        }
    }
}
