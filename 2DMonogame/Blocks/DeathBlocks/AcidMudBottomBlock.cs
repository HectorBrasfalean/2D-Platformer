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
    /// Verantwoordelijk voor het acidmudbottom blok
    /// </summary>
    class AcidMudBottomBlock : StaticBlock,IDeathBlock
    {
        public AcidMudBottomBlock(ContentManager content, string name) : base(content, name)
        {

        }

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        /// <summary>
        /// Tekent de acidmudbottom blok
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
