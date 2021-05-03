using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace AlgoTri_TPI
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gamteTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
