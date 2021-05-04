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


        private Color _color;
        static Random rdm = new Random();
        public Vector2 Position { get => _position; set => _position = value; }
        public int Value { get => _value; set => _value = value; }
        public Color Color { get => _color; set => _color = value; }
        public Vector2 StartPos { get => _startPos; set => _startPos = value; }

        public RectangleValue(Texture2D texture, Vector2 startPosition, SpriteFont font, int value, Color color)
        {
            Texture = texture;
            Position = startPosition;
            StartPos = startPosition;
            _spriteFont = font;
            Value = value;
            Color = color;
        }
        public override void Draw(GameTime gamteTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_spriteFont,Value.ToString(),new Vector2(Position.X + 10, Position.Y + 15),Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
        }
        public void moveRight() {
            _position.X += 5;
        }
        public void moveLeft()
        {
            _position.X -= 5;
        }
        public Vector2 MoveTo(Vector2 PositionToGo) {

            if (Position.X < PositionToGo.X)
                moveRight();
            else if (Position.X > PositionToGo.X)
                moveLeft();
            return StartPos;
        }
    }
}
