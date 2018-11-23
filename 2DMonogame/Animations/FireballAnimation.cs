﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations
{
    class FireballAnimation : Animation
    {
        public FireballAnimation()
        {
            Speed = 50;
        }
        protected override void AddAnimation()
        {
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(0, 275, 64, 19) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(64, 275, 64, 19) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(128, 275, 64, 19) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(192, 275, 64, 19) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(256, 275, 64, 19) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(320, 275, 64, 19) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(384, 275, 64, 19) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(448, 275, 64, 19) });
        }
    }
}
