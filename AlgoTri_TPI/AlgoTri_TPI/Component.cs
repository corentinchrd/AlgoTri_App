/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est la classe abstraite des composants
 Date : 19.05.2021
 */
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
        /// <summary>
        /// Dessine le composant
        /// </summary>
        /// <param name="gamteTime"></param>
        /// <param name="spriteBatch"></param>
        public abstract void Draw(GameTime gamteTime, SpriteBatch spriteBatch);
        /// <summary>
        /// Met a jour le composant
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);
    }
}
