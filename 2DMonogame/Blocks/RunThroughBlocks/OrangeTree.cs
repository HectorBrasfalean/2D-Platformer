using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DMonogame.Blocks.RunThroughBlocks
{
    /// <summary>
    /// Verantwoordelijk voor de oranje bomen
    /// </summary>
    class OrangeTree : RunThroughBlocks
    {
        public OrangeTree(ContentManager content, string name) : base(content, name)
        {
        }

        /// <summary>
        /// Tekent de oranje bomen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
