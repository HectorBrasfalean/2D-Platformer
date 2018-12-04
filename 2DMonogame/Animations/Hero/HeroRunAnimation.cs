using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de hero run animatie
    /// </summary>
    class HeroRunAnimation : Animation
    {
        public HeroRunAnimation()
        {
            PlaySpeed = 100;
        }
        /// <summary>
        /// Voegt een run animatie toe aan het animatie object door middel van bepaalde frames
        /// </summary>
        protected override void AddAnimation()
        {
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(0, 370, 488, 370) });
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(488, 370, 488, 370) });
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(976, 370, 488, 370) });
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(1464, 370, 488, 370) });
            this.AddFrame(new AnimationFrame() { scale = 0.24f, RectangleSelector = new Rectangle(0, 795, 488, 420) });
        }
    }
}
