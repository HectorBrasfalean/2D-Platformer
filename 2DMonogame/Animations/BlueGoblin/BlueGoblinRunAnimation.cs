using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.BlueGoblin
{
    /// <summary>
    /// Verantwoordelijk voor de run animatie van de blauwe goblin
    /// </summary>
    class BlueGoblinRunAnimation : Animation
    {
        public BlueGoblinRunAnimation()
        {
            PlaySpeed = 300;
        }

        /// <summary>
        /// Zet alle frames samen zodat we een run animatie bekomen voor de blauwe goblin
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 1536, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 1536, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 1792, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 1792, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 1792, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 1792, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 1792, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 1792, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 2048, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 2048, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 2048, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 2048, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 2048, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 2048, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(0, 2304, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(301, 2304, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(602, 2304, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(903, 2304, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1204, 2304, 301, 260) });
            AddFrame(new AnimationFrame() { scale = 0.35f, RectangleSelector = new Rectangle(1505, 2304, 301, 260) });
        }
    }
}
