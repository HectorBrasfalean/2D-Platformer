using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations
{
    /// <summary>
    /// Verantwoordelijk voor de giant aanval animatie
    /// </summary>
    class GiantAttackAnimation : Animation
    {
        public GiantAttackAnimation()
        {
            PlaySpeed = 250;
        }
        /// <summary>
        /// Voegt de volledige aanval animatie toe aan de hand van verschillende frames
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(0, 0, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(445, 0, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(890, 0, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1335, 0, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1780, 0, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2225, 0, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2670, 0, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3115, 0, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3560, 0, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(0, 420, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(445, 420, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(890, 420, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1335, 420, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(1780, 420, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2225, 420, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(2670, 420, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3115, 420, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(3560, 420, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(0, 840, 445, 410) });
            AddFrame(new AnimationFrame() { scale = 0.5f, RectangleSelector = new Rectangle(445, 840, 445, 410) });
        }
    }
}
