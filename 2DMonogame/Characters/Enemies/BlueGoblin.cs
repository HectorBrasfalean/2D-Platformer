﻿using _2DMonogame.Animations.BlueGoblin;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Characters
{
    class BlueGoblin : Enemy
    {
        public BlueGoblin(ContentManager content, string name) : base(content, name)
        {
            AttackAnimation = new BlueGoblinAttackAnimation();
            RunAnimation = new BlueGoblinRunAnimation();
            DeathAnimation = new BlueGoblinDieAnimation();
            CurrentAnimation = RunAnimation;
        }

        public override float MovingSpeed => 4f;
    }
 }

