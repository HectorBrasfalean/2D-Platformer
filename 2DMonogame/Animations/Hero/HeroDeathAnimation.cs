using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de hero dood animatie
    /// </summary>
    class HeroDeathAnimation : Animation
    {
        public HeroDeathAnimation()
        {
            PlaySpeed = 50;
        }
        /// <summary>
        /// Voegt een dood animatie toe aan het animatie object door middel van bepaalde frames
        /// </summary>
        protected override void AddAnimation()
        {
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(0, 3028, 381, 363) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(381, 3028, 381, 363) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(762, 3028, 381, 363) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(1143, 3028, 381, 363) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(1524, 3048, 381, 343) });
        }
    }
}
