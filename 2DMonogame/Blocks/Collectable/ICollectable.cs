using _2DMonogame.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Blocks.Collectable
{
    interface ICollectable : ICollide
    {
        bool IsCollected { get; set; }
        //void Update(List<ICollide> collisionObjects,Collider collider);
    }
}
