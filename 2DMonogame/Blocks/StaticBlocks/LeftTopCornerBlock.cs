using System;
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
    /// Verantwoordelijk voor de lefttopcorner blok
    /// </summary>
    class LeftTopCornerBlock : StaticBlock
    {
        public LeftTopCornerBlock(ContentManager content, string name) : base(content, name)
        {

        }

        /// <summary>
        /// Verantwoordelijk voor de lefttopcorner blok
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
