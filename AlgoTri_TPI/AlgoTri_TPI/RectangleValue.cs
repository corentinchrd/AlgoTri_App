using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI
{
    public class RectangleValue : Component
    {
        private SpriteFont _spriteFont;
        private Vector2 _position;
        private int _value;
        public Texture2D Texture;
        public int width = 40;
        public int HEIGHT = 10;
        private Vector2 _startPos;
        private int _positionIndex;

        private Color _color;
        private bool isSelected;
        static Random rdm = new Random();
        public Vector2 Position { get => _position; set => _position = value; }
        public int Value { get => _value; set => _value = value; }
        public Color Color { get => _color; set => _color = value; }
        public Vector2 StartPos { get => _startPos; set => _startPos = value; }
        public int PositionIndex { get => _positionIndex; set => _positionIndex = value; }
        public bool IsSelected { get => isSelected; set => isSelected = value; }

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
        public override void Draw(GameTime gamteTime, SpriteBatch spriteBatch)
        {
            if (IsSelected == false)
                spriteBatch.DrawString(_spriteFont, Value.ToString(), new Vector2(Position.X + 10, Position.Y + 15), Color.Black);
            else
                spriteBatch.DrawString(_spriteFont, Value.ToString(), new Vector2(Position.X + 10, Position.Y + 15), Color.Red);
        }

        public override void Update(GameTime gameTime)
        {
        }
        public void moveRight()
        {
            _position.X += 5;
        }
        public void moveDown()
        {
            _position.Y += 50;
        }
        public void moveUp()
        {
            _position.Y -= 50;
        }
        public void moveLeft()
        {
            _position.X -= 5;
        }
        public void MoveTo(Vector2 PositionToGo)
        {
            if (Position.X < PositionToGo.X)
                moveRight();
            else if (Position.X > PositionToGo.X)
                moveLeft();
        }
        public void UpdatePos(int p)
        {
            Position = new Vector2(p, Position.Y);
        }
    }
}
