using _2DMonogame.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Characters
{
    /// <summary>
    /// Verantwoordelijk voor elk object die collectables kan collecteren
    /// </summary>
    interface ICanCollect : IMovingCollide
    {
        bool HasTouchedCollectable { get; set; }
    }
}
