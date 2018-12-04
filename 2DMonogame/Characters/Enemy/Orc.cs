﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DMonogame.Characters
{
    class Orc : Enemy
    {
        public Orc(ContentManager content,string name) : base(content, name)
        {
        }

        public override float MovingSpeed => 1.5f;
    }
}
