using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DMonogame.Blocks.InvisibleBlocks
{
    /// <summary>
    /// Verantwoordelijk voor de onzichtbare blokken
    /// </summary>
    class InvisibleBlock : GameObject,IInvisible
    {
        public InvisibleBlock(ContentManager content, string name) : base(content, name)
        {
        }

        public Rectangle CollisionRectangle => new Rectangle((int)Position.X,(int)Position.Y,Texture.Width,Texture.Height);

        /// <summary>
        /// Tekent de onzichtbare blok
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
