using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Blocks
{
    /// <summary>
    /// Verantwoordelijk voor elke bewegende blok
    /// </summary>
    interface IMoveBlock : IMovingCollide
    {
        void Update(List<ICollide> collisionObjects, Collider collider);
    }
}
