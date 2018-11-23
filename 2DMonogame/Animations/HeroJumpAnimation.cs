using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    class HeroJumpAnimation : Animation
    {
        public HeroJumpAnimation()
        {
            Speed = 40;
        }
        protected override void AddAnimation()
        {
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(488, 781, 402, 436) });
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(890, 781, 402, 436) });
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(1292, 781, 402, 436) });
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(0, 1212, 402, 436) });
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(402, 1232, 402, 436) });
        }
    }
}
