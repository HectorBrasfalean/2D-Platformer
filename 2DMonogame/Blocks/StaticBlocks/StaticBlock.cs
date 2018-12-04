using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Content;
using _2DMonogame.Collision;
using _2DMonogame.Blocks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor elke static blok
    /// </summary>
    abstract class StaticBlock : GameObject,ICollide
    {
        public Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        public StaticBlock(ContentManager content,string name) : base(content,name)
        {
            
        }


    }
}
