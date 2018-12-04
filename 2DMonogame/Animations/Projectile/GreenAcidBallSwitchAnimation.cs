using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.Projectile
{
    class GreenAcidBallSwitchAnimation : Animation
    {
        public GreenAcidBallSwitchAnimation()
        {
            PlaySpeed = 20;
        }

        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(29, 4, 6, 24) });
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(29, 40, 6, 16) });
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(29, 68, 6, 8) });
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(29, 88, 6, 8) });
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(29, 108, 6, 16) });
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(29, 136, 6, 24) });
        }
    }
}
