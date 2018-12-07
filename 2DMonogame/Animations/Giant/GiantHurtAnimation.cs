using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.Giant
{
    class GiantHurtAnimation : Animation
    {
        /// <summary>
        /// Verantwoordelijk voor de animatie wanneer de giant geraakt wordt maar niet dood gaat
        /// </summary>
        public GiantHurtAnimation()
        {
            PlaySpeed = 250;
        }
        /// <summary>
        /// Het samenvoegen van alle frames zodat we 1 animatie bekomen
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1780, 1680, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2225, 1680, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2670, 1680, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3115, 1680, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3560, 1680, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(0, 2100, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(445, 2100, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(890, 2100, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1335, 2100, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1780, 2100, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2225, 2100, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2670, 2100, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3115, 2100, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3560, 2100, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(0, 2520, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(445, 2520, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(890, 2520, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1335, 2520, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1780, 2520, 300, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2225, 2520, 300, 395) });
        }
    }
}
