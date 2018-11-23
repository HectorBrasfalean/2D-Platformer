using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    abstract class Movement
    {
        public int movementSpeed = 4;
        public bool Left;
        public bool Right;
        public bool Jump;
        public bool Attack;
        abstract public void Update(Hero hero);
    }
}
