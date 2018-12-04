using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.Giant
{
    /// <summary>
    /// Verantwoordelijk voor de loop animatie van de giant
    /// </summary>
    class GiantRunAnimation : Animation
    {
        public GiantRunAnimation()
        {
            PlaySpeed = 200;
        }

        /// <summary>
        /// Samenvoegen van alle frames zodat we de loop animatie bekomen
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() {scale = 0.5f, RectangleSelector = new Rectangle(2670, 2520, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3115, 2520, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3560, 2520, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(0, 2940, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(445, 2940, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(890, 2940, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1335, 2940, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1780, 2940, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2225, 2940, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2670, 2940, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3115, 2940, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3560, 2940, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(0, 3360, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(445, 3360, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(890, 3360, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1335, 3360, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1780, 3360, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2225, 3360, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2670, 3360, 405, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3115, 3360, 405, 410) });
        }
    }
}
