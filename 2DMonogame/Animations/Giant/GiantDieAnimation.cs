using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.Giant
{
    /// <summary>
    /// Verantwoordelijk voor de animatie waar de giant dood gaat
    /// </summary>
    class GiantDieAnimation : Animation
    {
        public GiantDieAnimation()
        {
            PlaySpeed = 300;
        }
        /// <summary>
        /// Voegt alle frames toe die we nodig hebben voor het bekomen van de animatie
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(890, 840, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1335, 840, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1780, 840, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2225, 840, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2670, 840, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3115, 840, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3560, 840, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(0, 1260, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(445, 1260, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(890, 1260, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1335, 1260, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1780, 1260, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2225, 1260, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2670, 1260, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3115, 1260, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3560, 1260, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(0, 1680, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(445, 1680, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(890, 1680, 430, 395) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1335, 1680, 430, 395) });
        }
    }
}
