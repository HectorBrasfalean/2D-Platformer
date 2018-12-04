using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de hero idle animatie
    /// </summary>
    class HeroIdleAnimation : Animation
    {
        public HeroIdleAnimation()
        {
            PlaySpeed = 50;
        }
        /// <summary>
        /// Voegt een idle animatie toe aan het animatie object door middel van bepaalde frames
        /// </summary>
        protected override void AddAnimation()
        {
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(0, 0, 387, 350) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(387, 0, 387, 350) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(774, 0, 387, 350) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(1161, 0, 387, 350) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(1548, 0, 387, 350) });
        }
    }
}
