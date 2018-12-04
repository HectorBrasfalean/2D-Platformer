using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Blocks.RunThroughBlocks
{
    /// <summary>
    /// Verantwoordelijk voor elk object waar we kunnen door lopen
    /// </summary>
    abstract class RunThroughBlocks : GameObject
    {

        public RunThroughBlocks(ContentManager content,string name) : base(content,name)
        {
            
        }

    }
}
