﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using AlgoTri_TPI.Affichage;

namespace AlgoTri_TPI.States
{
    public class InsertionState : State
    {
        private List<Component> _components;
        Texture2D rectangleSprite;
        SpriteFont buttonFont;
        public List<RectangleValue> _rectangles;
        private List<Color> _colors;
        private bool NeedToMove = false;
        private int[] numberMove = new int[2];
        static Random rdm = new Random();
        private Tri.Insertiontri insertionTri;
        private AfficherInsertion afficherInsertion;
        private List<Position> _allPosition;

        public List<Position> AllPosition { get => _allPosition; set => _allPosition = value; }

        public InsertionState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            insertionTri = new Tri.Insertiontri();
            insertionTri.Random();
            Texture2D buttonTexture = _content.Load<Texture2D>("Controls/Button");
            rectangleSprite = _content.Load<Texture2D>("Controls/1px");
            buttonFont = _content.Load<SpriteFont>("Fonts/File");
            AllPosition = new List<Position>();

            afficherInsertion = new AfficherInsertion(rectangleSprite, buttonFont, insertionTri.Values);

            _components = new List<Component>();

            _rectangles = new List<RectangleValue>();
            #region Color
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
            afficherRectangle();
            Controls.Button SelectionButton = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(450, 150),
                Text = "Tri par insertion",
            };

            SelectionButton.Click += SelectionButton_Click;
            _components.Add(SelectionButton);
        }

        private void SelectionButton_Click(object sender, EventArgs e)
        {
           insertionTri.Sort();
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
            spriteBatch.DrawString(buttonFont, "Nombre d'iteration(s) :", new Vector2(15, 600), Color.Black);
            spriteBatch.DrawString(buttonFont, "0", new Vector2(215, 600), Color.Red);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            if (NeedToMove == true)
            {
                insertionTri.Sort();
            }
            foreach (Component component in _components)
            {
                component.Update(gameTime);
            }
        }

        public void afficherRectangle()
        {
            _rectangles = afficherInsertion.afficherList();
            foreach (RectangleValue rectangle in _rectangles)
            {
                _components.Add(rectangle);
            }
        }

        public void InvertTwoRect(RectangleValue rt1, RectangleValue rt2)
        {
            while(NeedToMove == true) { 
            if (rt1.Position.X != rt2.StartPos.X)
            {
                _rectangles = afficherInsertion.switchTwoValues(_rectangles, _rectangles.IndexOf(rt1), _rectangles.IndexOf(rt2));
            }
            else
            {
                rt1.StartPos = rt1.Position;
                rt2.StartPos = rt2.Position;
                    NeedToMove = false;
            }
            }
        }
    }
}
