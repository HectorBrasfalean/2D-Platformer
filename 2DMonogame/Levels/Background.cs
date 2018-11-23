﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    class Background
    {
        public Texture2D backgroundTexture;
        Vector2 position;
        public Background(Vector2 position)
        {
            this.position = position;
        }
        public void Update(float position)
        {
            this.position.X = position - 1000;
           

        }
        public void Draw(SpriteBatch spriteBatch,GraphicsDevice graphics)
        {
            spriteBatch.Draw(backgroundTexture, position, null, Color.AliceBlue, 0f, Vector2.Zero,1f, SpriteEffects.None, 0f);
        }
    }
}
