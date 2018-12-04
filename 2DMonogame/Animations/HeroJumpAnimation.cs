using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de hero jump animatie
    /// </summary>
    class HeroJumpAnimation : Animation
    {
        public HeroJumpAnimation()
        {
            Speed = 40;
        }
        /// <summary>
        /// Voegt een jump animatie toe aan het animatie object door middel van bepaalde frames
        /// </summary>
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
