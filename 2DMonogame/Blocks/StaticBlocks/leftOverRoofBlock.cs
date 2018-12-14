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
    /// Verantwoordelijk voor de linkse overkaping blok
    /// </summary>
    class LeftOverRoofBlock : StaticBlock
    {
        public LeftOverRoofBlock(ContentManager content, string name) : base(content, name)
        {
        }

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        /// <summary>
        /// Tekent de linkse overkaping blok
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
