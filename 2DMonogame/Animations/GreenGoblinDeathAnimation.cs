using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations
{
    class GreenGoblinDeathAnimation : Animation
    {
        public GreenGoblinDeathAnimation()
        {
            Speed = 40;
        }
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(0,0,0,0)});
        }
    }
}
