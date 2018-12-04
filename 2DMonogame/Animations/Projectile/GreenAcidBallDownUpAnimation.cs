using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.Projectile
{
    class GreenAcidBallDownUpAnimation : Animation
    {
        public GreenAcidBallDownUpAnimation()
        {
            PlaySpeed = 20;
        }

        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(5, 4, 6, 24) });
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(29, 4, 6, 24) });
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(53, 4, 6, 24) });
            AddFrame(new AnimationFrame() { scale = 1.5f, RectangleSelector = new Rectangle(77, 4, 6, 24) });
        }
    }
}
