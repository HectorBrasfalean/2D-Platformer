using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de hero aanval animatie
    /// </summary>
    class HeroAttackAnimation : Animation
    {
        public HeroAttackAnimation()
        {
            PlaySpeed = 60;
        }
        /// <summary>
        /// Voegt een aanval animatie toe aan het animatie object door middel van bepaalde frames
        /// </summary>
        protected override void AddAnimation()
        {
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(804, 1302,440, 434) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(0, 1748, 440, 434) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(685, 1748, 440, 434) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(0, 2222, 440, 434) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(685, 2222, 440, 434) });
        }
    }
}
