using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DMonogame.Blocks.Collectable
{
    /// <summary>
    /// Verantwoordelijk voor elk ster collectable
    /// </summary>
    class StarCollectable : StaticBlock,ICollectable
    {
        public StarCollectable(ContentManager content, string name) : base(content,name)
        {
            
        }
        public bool IsCollected { get; set; }

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        /// <summary>
        /// Tekenen van de ster op het scherm
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if(!IsCollected)
                spriteBatch.Draw(Texture,new Vector2(Position.X+25,Position.Y), Color.AliceBlue);
        }
    }
}
