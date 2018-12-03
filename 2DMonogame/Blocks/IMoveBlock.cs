using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Blocks
{
    interface IMoveBlock : IMovingCollide
    {
        //IMovingCollide currentCollisionBlock { get; set; }
        void Update(List<ICollide> collisionObjects, Collider collider);
    }
}
