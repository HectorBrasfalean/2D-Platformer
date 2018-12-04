using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations
{
    /// <summary>
    /// Verantwoordelijk voor het groene goblin loop animatie
    /// </summary>
    class GreenGoblinRunAnimation : Animation
    {
        public GreenGoblinRunAnimation()
        {
            Speed = 200;
        }
        /// <summary>
        /// Voegt een run animatie toe aan het animatie object door middel van bepaalde frames
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1320, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1452, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1584, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1716, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1848, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(0, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(132, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(264, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(396, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(528, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(660, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(792, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(924, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1056, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1188, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1320, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1452, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1584, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1716, 357, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1848, 357, 132, 119) });
        }
    }
}
