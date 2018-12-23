using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Collision
{
    /// <summary>
    /// Verantwoordelijk voor elk collision object dat kan colliden met iets
    /// </summary>
    public interface ICollide 
    {

        Rectangle CollisionRectangle { get; }

    }
}
