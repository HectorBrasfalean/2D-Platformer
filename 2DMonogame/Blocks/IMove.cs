using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Blocks
{
    interface IMove : IMovingCollide
    {
        void Update(List<ICollide> collisionObjects, Collider collider);
    }
}
