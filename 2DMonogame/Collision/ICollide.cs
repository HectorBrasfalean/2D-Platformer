using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Collision
{
    /// <summary>
    /// Verantwoordelijk voor de collision eigenschappen die we gebruiken in collision detection
    /// </summary>
    public interface ICollide 
    {
        Vector2 Position { get; set; }
        Rectangle CollisionRectangle { get; }

    }
}
