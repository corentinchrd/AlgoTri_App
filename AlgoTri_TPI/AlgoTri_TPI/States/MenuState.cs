/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script contient tout ce qui est affiché sur la page des menus ou l'on peut choisir quel tri choisir
 Date : 19.05.2021
 */

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
        Texture2D Logotexture;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            //Declaration des textures et de la font pour tout les boutons
            Texture2D buttonTexture = _content.Load<Texture2D>("Controls/Button");
            SpriteFont buttonFont = _content.Load<SpriteFont>("Fonts/File");
            Logotexture = _content.Load<Texture2D>("Controls/Logo");
            #region bouton
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

#endregion
            _components = new List<Component>() {
                InsertionButton,
                BulleButton,
                SelectionButton,
                PeigneButton,
                ShellButton,
                AboutButton,
            };
        }
        /// <summary>
        /// Permet de changer d'etape lors d'un clique sur un bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertionButton_Click(object sender, EventArgs e)
        {
            //Creation d'un nouveau state à afficher
            _game.ChangeState(new InsertionState(_game, _graphicsDevice, _content));
        }
        /// <summary>
        /// Permet de changer d'etape lors d'un clique sur un bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BulleButton_Click(object sender, EventArgs e)
        {
            //Creation d'un nouveau state à afficher
            _game.ChangeState(new BulleState(_game, _graphicsDevice, _content));
        }
        /// <summary>
        /// Permet de changer d'etape lors d'un clique sur un bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionButton_Click(object sender, EventArgs e)
        {
            //Creation d'un nouveau state à afficher
            _game.ChangeState(new SelectionState(_game, _graphicsDevice, _content));
        }
        /// <summary>
        /// Permet de changer d'etape lors d'un clique sur un bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeigneButton_Click(object sender, EventArgs e)
        {
            //Creation d'un nouveau state à afficher
            _game.ChangeState(new PeigneState(_game, _graphicsDevice, _content));
        }
        /// <summary>
        /// Permet de changer d'etape lors d'un clique sur un bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShellButton_Click(object sender, EventArgs e)
        {
            //Creation d'un nouveau state à afficher
            _game.ChangeState(new ShellState(_game, _graphicsDevice, _content));
        }
        /// <summary>
        /// Permet d'ouvrir le pdf lorsqu'on clique sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutButton_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"C:\Users\Corentin\Desktop\TPI_Doc.pdf");
        }
        /// <summary>
        /// Fonction appelée pour dessiner a l'ecran les objets
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //permet de dessiner tout les composants
            spriteBatch.Begin();
            spriteBatch.Draw(Logotexture,new Vector2(275,125),Color.White);
            foreach (Component component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
        }
        /// <summary>
        /// Fonction appelé apres le update et le draw pour detruire les items
        /// </summary>
        /// <param name="gameTime"></param>
        public override void PostUpdate(GameTime gameTime)
        {            
        }
        /// <summary>
        /// Fonction appelé le plus souvent possible meme si l'application est lente
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Permet de mettre à jour tout les composants sur la page
            foreach (Component component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
