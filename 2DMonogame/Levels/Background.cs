using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de background
    /// </summary>
    class Background
    {
        public Texture2D BackgroundTexture;
        Vector2 position;
        public Background(Vector2 position)
        {
            this.position = position;
        }
        /// <summary>
        /// Update de background positie met de meegegeven positie
        /// </summary>
        /// <param name="position">Positie op de x-as die wordt meegegeven</param>
        public void Update(float position)
        {
            this.position.X = position - 1000;
        }

        /// <summary>
        /// Tekent de background op het scherm
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, position, null, Color.AliceBlue, 0f, Vector2.Zero,1f, SpriteEffects.None, 0f);
        }
    }
}
