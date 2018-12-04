using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations
{
    /// <summary>
    /// Verantwoordelijk voor de groene goblin dood animatie
    /// </summary>
    class GreenGoblinDeathAnimation : Animation
    {
        public GreenGoblinDeathAnimation()
        {
            Speed = 400;
        }
        /// <summary>
        /// Voegt een dood animatie toe aan het animatie object door middel van bepaalde frames
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(660, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(792, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(924, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1056, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1188, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1320, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1452, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1584, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1716, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1848, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(0, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(132, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(264, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(396, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(528, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(660, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(792, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(924, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1056, 238, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1188, 238, 132, 119) });
        }
    }
}
