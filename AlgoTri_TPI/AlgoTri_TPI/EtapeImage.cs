/*
 Auteur : Corentin Chuard
 Version : 1.0.0
 Description : Ce script est la classe qui permet d'afficher l'image de l'etape avec une opacité
 Date : 19.05.2021
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI
{
    public class EtapeImage : Component
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
        /// <summary>
        /// Dessine le composant avec l'opacité
        /// </summary>
        /// <param name="gamteTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gamteTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White * opacity);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
