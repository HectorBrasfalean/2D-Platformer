using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DMonogame.Characters
{
    class Giant : Enemy
    {
        public Giant(ContentManager content, Vector2 startPositionEnemy) : base(content, startPositionEnemy)
        {
        }
    }
}
