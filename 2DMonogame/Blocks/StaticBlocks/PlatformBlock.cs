﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Blocks.StaticBlocks
{
    /// <summary>
    /// Verantwoordelijk voor de platform blok
    /// </summary>
    class PlatformBlock : StaticBlock
    {
        public PlatformBlock(ContentManager content, string name) : base(content, name)
        {

        }

        /// <summary>
        /// Tekent de platform blok
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
