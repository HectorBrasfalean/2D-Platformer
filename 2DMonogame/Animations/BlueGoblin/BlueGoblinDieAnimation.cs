using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.BlueGoblin
{
    /// <summary>
    /// Verantwoordelijk voor de dood animatie van de blauwe goblin
    /// </summary>
    class BlueGoblinDieAnimation : Animation
    {
        public BlueGoblinDieAnimation()
        {
            PlaySpeed = 300;
        }

        /// <summary>
        /// Voegt alle frames samen die we nodig hebben voor de dood animatie van de blauwe goblin
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 768, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 768, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 768, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 768, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 1024, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 1024, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 1024, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 1024, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 1024, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 1024, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 1280, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 1280, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 1280, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 1280, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 1280, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 1280, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 1536, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 1536, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 1536, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 1536, 301, 260) });
        }
    }
}
