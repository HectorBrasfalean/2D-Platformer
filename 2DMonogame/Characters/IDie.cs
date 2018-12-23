using _2DMonogame.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Characters
{
    /// <summary>
    /// Verantwoordelijk voor het object dat kan doodgaan
    /// </summary>
    interface IDie : ICollide
    {
        bool IsHit { get; set; }
    }
}
