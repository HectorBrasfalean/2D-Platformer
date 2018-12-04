using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.BlueGoblin
{
    /// <summary>
    /// Verantwoordelijk voor de aanval animatie van de blauwe goblin
    /// </summary>
    class BlueGoblinAttackAnimation : Animation
    {
        public BlueGoblinAttackAnimation()
        {
            PlaySpeed = 300;
        }

        /// <summary>
        /// Voegt alle frames samen die we nodig hebben voor de aanval animatie van de blauwe goblin
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 0, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 0, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 0, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 0, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 0, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 0, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 256, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 256, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 256, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 256, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 256, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 256, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 512, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 512, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 512, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 512, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 512, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 512, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 768, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 768, 301, 260) });
        }
    }
}
