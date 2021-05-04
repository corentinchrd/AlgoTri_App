using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI.States
{
    public class InsertionState : State
    {
        private List<Component> _components;
        Texture2D rectangleSprite;
        SpriteFont buttonFont;
        private List<RectangleValue> _rectangles;
        private List<Color> _colors;
        private bool NeedToMove = false;
        private int[] numberMove = new int[2];
        static Random rdm = new Random();
        
        
        public InsertionState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Tri.Insertiontri insertionTri = new Tri.Insertiontri();
            Tri.SelectionTri selectiontri = new Tri.SelectionTri();
            Tri.PeigneTri PeigneTri = new Tri.PeigneTri();
            Tri.ShellTri ShellTri = new Tri.ShellTri();
            Texture2D buttonTexture = _content.Load<Texture2D>("Controls/Button");
            rectangleSprite = _content.Load<Texture2D>("Controls/1px");
            buttonFont = _content.Load<SpriteFont>("Fonts/File");
            _components = new List<Component>();

            _rectangles = new List<RectangleValue>();

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
            afficherRectangle();
            Controls.Button SelectionButton = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(450, 150),
                Text = "Tri par selection",
            };

            SelectionButton.Click += SelectionButton_Click;
            _components.Add(SelectionButton);
        }

        private void SelectionButton_Click(object sender, EventArgs e)
        {
            numberMove[0] = rdm.Next(0, 19);
            numberMove[1] = rdm.Next(0, 19);
            NeedToMove = true;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var component in _components)
            {
                if (component is RectangleValue)
                {
                    RectangleValue tmp = component as RectangleValue;
                    spriteBatch.Draw(tmp.Texture,
                        new Rectangle((int)tmp.Position.X, (int)tmp.Position.Y - (tmp.HEIGHT * tmp.Value - tmp.HEIGHT), tmp.width, tmp.HEIGHT * tmp.Value),
                        new Rectangle(0, 0, 1, 1), tmp.Color);
                    tmp.Draw(gameTime, spriteBatch);
                }
                else
                {
                    component.Draw(gameTime, spriteBatch);
                }
            }
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            if (NeedToMove == true) {
                InvertTwoRect(_rectangles[numberMove[0]], _rectangles[numberMove[1]]);
            }
            foreach (Component component in _components)
            {
                if (component is RectangleValue)
                {
                    RectangleValue rt = component as RectangleValue;
                    if (NeedToMove == true)
                    {
                    }
                }
                component.Update(gameTime);
            }
        }

        public void afficherRectangle()
        {
            int space = 45;
            for (int i = 0; i < 20; i++)
            {
                RectangleValue rt = new RectangleValue(rectangleSprite, new Vector2(152f + space * i, 350), buttonFont, i + 1, _colors[i]);
                _components.Add(rt);
                _rectangles.Add(rt);

            }
        }

        public void InvertTwoRect(RectangleValue rt1, RectangleValue rt2) {
            rt1.MoveTo(rt2.StartPos);
            rt2.MoveTo(rt1.StartPos);
        }
    }
}
