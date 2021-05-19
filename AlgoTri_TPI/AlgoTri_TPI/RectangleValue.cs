/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est la classe des rectangles
 Date : 19.05.2021
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI
{
    public class RectangleValue : Component
    {
        #region Champ
        private SpriteFont _spriteFont;
        private Vector2 _position;
        private int _value;
        private Vector2 _startPos;
        private int _positionIndex;
        private Color _color;
        private bool isSelected;
        private int decalage = 0;
        #endregion
        #region Propriété
        public Texture2D Texture;
        public int width = 40;
        public int HEIGHT = 10;

        static Random rdm = new Random();
        public Vector2 Position { get => _position; set => _position = value; }
        public int Value { get => _value; set => _value = value; }
        public Color Color { get => _color; set => _color = value; }
        public Vector2 StartPos { get => _startPos; set => _startPos = value; }
        public int PositionIndex { get => _positionIndex; set => _positionIndex = value; }
        public bool IsSelected { get => isSelected; set => isSelected = value; }
        #endregion
        public RectangleValue(Texture2D texture, Vector2 pos, SpriteFont font, int value, Color color, int sp)
        {
            Texture = texture;
            Position = pos;
            if (StartPos == new Vector2(0, 0))
            {
                StartPos = pos;
            }
            _spriteFont = font;
            Value = value;
            Color = color;
            PositionIndex = sp;
            IsSelected = false;
        }
        /// <summary>
        /// Change la couleur du texte si il est sélécitonné
        /// </summary>
        /// <param name="gamteTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gamteTime, SpriteBatch spriteBatch)
        {
            if (IsSelected == false)
                spriteBatch.DrawString(_spriteFont, Value.ToString(), new Vector2(Position.X + 10, Position.Y + 15), Color.Black);
            else
                spriteBatch.DrawString(_spriteFont, Value.ToString(), new Vector2(Position.X + 10, Position.Y + 15), Color.Red);
        }
        /// <summary>
        /// Est appelé lke plus souvent possible
        /// </summary>
        /// <param name="gamteTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Update(GameTime gameTime)
        {
        }
        /// <summary>
        /// Peremet de déplacer le rectangle a droite
        /// </summary>
        public void moveRight()
        {
            _position.X += 1;
        }
        /// <summary>
        /// Peremet de déplacer le rectangle vers le bas
        /// </summary>
        public void moveDown()
        {
            _position.Y += 50;
        }/// <summary>
         /// Peremet de déplacer le rectangle vers le bas pour le tri a shell
         /// </summary>
         /// <param name="i"></param>
        public void moveDownMultiple(int i)
        {
            decalage = i * 25;
            _position.Y += 25 * i;
        }

        /// <summary>
        /// Peremet de déplacer le rectangle vers le haut pour le tri a shell
        /// </summary>
        /// <param name="i"></param>
        public void moveUpMultiple(int i)
        {
            decalage = i * 25;
            _position.Y -= 25 * i;
        }/// <summary>
         /// Peremet de déplacer le rectangle vers le haut
         /// </summary>
        public void moveUp()
        {
            _position.Y -= 50;
        }/// <summary>
         /// Peremet de déplacer le rectangle a gauche
         /// </summary>
        public void moveLeft()
        {
            _position.X -= 1;
        }/// <summary>
         /// Peremet de déplacer le rectangle vers ca place initiale en hauteur
         /// </summary>
         /// <param name="i"></param>
        public void moveOriginalPos()
        {
            _position.Y = _startPos.Y;
        }
        /// <summary>
        /// fait déplacer le rectangle vers une position
        /// </summary>
        /// <param name="PositionToGo"></param>
        /// <returns></returns>
        public bool MoveTo(Vector2 PositionToGo)
        {
            if (Position.X < PositionToGo.X)
                moveRight();
            else if (Position.X > PositionToGo.X)
                moveLeft();

            if (Position.X == PositionToGo.X) {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Permet de changer la position instantanement du rectangle
        /// </summary>
        /// <param name="p"></param>
        public void UpdatePos(int p)
        {
            Position = new Vector2(p, Position.Y);
        }
    }
}
