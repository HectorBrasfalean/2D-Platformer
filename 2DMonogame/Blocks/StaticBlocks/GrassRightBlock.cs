﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de grasssright blok
    /// </summary>
    class GrassRightBLock : StaticBlock
    {
        public GrassRightBLock(ContentManager content, string name) : base(content, name)
        {

        }

        /// <summary>
        /// Tekent de grassright blok
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
