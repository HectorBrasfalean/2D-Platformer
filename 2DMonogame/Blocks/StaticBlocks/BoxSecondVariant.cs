using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DMonogame.Blocks.StaticBlocks
{
    /// <summary>
    /// Verantwoordelijk voor de box second variant blok
    /// </summary>
    class BoxSecondVariant : StaticBlock
    {
        public BoxSecondVariant(ContentManager content, string name) : base(content, name)
        {
        }

        /// <summary>
        /// Tekent de tweede variant van de box
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
