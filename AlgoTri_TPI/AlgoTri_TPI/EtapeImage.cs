using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI
{
    class EtapeImage : Component
    {
        Vector2 position;
        public float opacity;
        Texture2D texture;

        public EtapeImage(Texture2D t, Vector2 pos,float opaci)
        {
            position = pos;
            opacity = opaci;
            texture = t;
        }
        public override void Draw(GameTime gamteTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White * opacity);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
