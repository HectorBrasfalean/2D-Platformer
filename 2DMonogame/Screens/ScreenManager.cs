using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Screens
{
    abstract class ScreenManager
    {

 
        public abstract void Draw(SpriteBatch sprite);
        public abstract void Update(GameTime gameTime);
    }
}
