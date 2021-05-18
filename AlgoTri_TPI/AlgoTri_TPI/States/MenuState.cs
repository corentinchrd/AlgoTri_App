using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace AlgoTri_TPI.States
{
    class MenuState : State
    {
        private List<Component> _components;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D buttonTexture = _content.Load<Texture2D>("Controls/Button");
            Texture2D aboutButtonTexture = _content.Load<Texture2D>("Controls/about");
            SpriteFont buttonFont = _content.Load<SpriteFont>("Fonts/File");

            Controls.Button InsertionButton = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(200, 200),
                Text = "Tri par insertion",
            };

            InsertionButton.Click += InsertionButton_Click;

            Controls.Button BulleButton = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(200, 250),
                Text = "Tri a bulle",
            };

            BulleButton.Click += BulleButton_Click;

            Controls.Button SelectionButton = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(200, 300),
                Text = "Tri par selection",
            };

            SelectionButton.Click += SelectionButton_Click;

            Controls.Button PeigneButton = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(200, 350),
                Text = "Tri a peigne",
            };

            PeigneButton.Click += PeigneButton_Click;

            Controls.Button ShellButton = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(200, 400),
                Text = "Tri Shell",
            };

            ShellButton.Click += ShellButton_Click;
            
            Controls.Button AboutButton = new Controls.Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1050, 600),
                Text = "?"
            };

            AboutButton.Click += AboutButton_Click;

            _components = new List<Component>() {
                InsertionButton,
                BulleButton,
                SelectionButton,
                PeigneButton,
                ShellButton,
                AboutButton,
            };
        }

        private void InsertionButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new InsertionState(_game, _graphicsDevice, _content));
        }

        private void BulleButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new BulleState(_game, _graphicsDevice, _content));
        }

        private void SelectionButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new SelectionState(_game, _graphicsDevice, _content));
        }
        private void PeigneButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new PeigneState(_game, _graphicsDevice, _content));
        }
        private void ShellButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new ShellState(_game, _graphicsDevice, _content));
        }
        private void AboutButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Corentin\Desktop\TPI_Doc.pdf");
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (Component component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Component component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
