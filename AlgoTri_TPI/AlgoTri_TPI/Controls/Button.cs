/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script permet d'afficher un bouton 
 Date : 19.05.2021
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTri_TPI.Controls
{
    public class Button : Component
    {
        #region Fields

        private MouseState _currentMouse; // Position actuel du curseur

        private SpriteFont _font; // Type de la font pour ecrire dans les boutons

        private bool _isHovering;

        private MouseState _previousMouse; // Position précédente du curseur

        private Texture2D _texture;

        public bool state = false;
        #endregion

        #region Properties

        public EventHandler Click;

        public bool Clicked { get; private set; }

        public float Layer { get; set; }

        // Millieu du bouton
        public Vector2 Origin
        {
            get
            {
                return new Vector2(_texture.Width / 2, _texture.Height / 2);
            }
        }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - ((int)Origin.X), (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
            }
        }

        public string Text;

        #endregion

        #region Methods

        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;

            _font = font;

            PenColour = Color.Black;
        }
        /// <summary>
        /// Fonction appelée apres le update
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Color colour = Color.White;

            if (_isHovering)
                colour = Color.Gray;

            spriteBatch.Draw(_texture, Position, null, colour, 0f, Origin, 1f, SpriteEffects.None, Layer);
            
            // Calcul de la taille du texte mais on ne peut pas ajouter d'accent car le measure string ne peut pas les interprétés
            if (!string.IsNullOrEmpty(Text))
            {
                float x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                float y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, Layer + 0.01f);
            }
        }
        /// <summary>
        /// Fonction appelée le plus souvent possible
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            Rectangle mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;
            //si la souris est en colision avec le rectangle du bouton
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    //Permet d'ajout la fonction .Click a notre bouton
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}
