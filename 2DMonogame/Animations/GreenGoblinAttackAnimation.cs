using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations
{
    class GreenGoblinAttackAnimation : Animation
    {
        public GreenGoblinAttackAnimation()
        {
            Speed = 300;
        }

        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(0, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(132, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(264, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(396, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(528, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(660, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(792, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(924, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1056, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1188, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1320, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1452, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1584, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1716, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(1848, 0, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(0, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(132, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(264, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(396, 119, 132, 119) });
            AddFrame(new AnimationFrame() { RectangleSelector = new Rectangle(528, 119, 132, 119) });
        }
    }
}
