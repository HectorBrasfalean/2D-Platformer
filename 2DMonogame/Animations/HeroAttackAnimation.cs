﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    class HeroAttackAnimation : Animation
    {
        public HeroAttackAnimation()
        {
            Speed = 50;
        }
        protected override void AddAnimation()
        {
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(804, 1302, 685, 434) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(0, 1748, 685, 434) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(685, 1748, 685, 434) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(0, 2222, 685, 434) });
            this.AddFrame(new AnimationFrame() { scale = 0.25f, RectangleSelector = new Rectangle(685, 2222, 685, 434) });
        }
    }
}