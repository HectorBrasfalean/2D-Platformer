using _2DMonogame.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Blocks.Collectable
{
    /// <summary>
    /// Verantwoordelijk voor elk Icollectable object
    /// </summary>
    interface ICollectable : ICollide
    {
        bool IsCollected { get; set; }
    }
}
