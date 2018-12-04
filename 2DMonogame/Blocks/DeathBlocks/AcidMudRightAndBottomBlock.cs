using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Blocks.DeathBlocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DMonogame.Blocks
{
    /// <summary>
    /// Verantwoordelijk voor het acidmudrightand bottom blok
    /// </summary>
    class AcidMudRightAndBottomBlock : StaticBlock, IDeathBlock
    {
        public AcidMudRightAndBottomBlock(ContentManager content, string name) : base(content, name)
        {

        }
        /// <summary>
        /// Tekent de acidmudrightandbottom blok
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
