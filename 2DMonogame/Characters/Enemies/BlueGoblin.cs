using _2DMonogame.Animations.BlueGoblin;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Characters
{
    class BlueGoblin : Enemy
    {
        public BlueGoblin(ContentManager content, string name) : base(content, name)
        {
            AttackAnimation = new BlueGoblinAttackAnimation();
            RunAnimation = new BlueGoblinRunAnimation();
            DeathAnimation = new BlueGoblinDieAnimation();
            CurrentAnimation = RunAnimation;
        }

        public override float MovingSpeed => 4f;

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X + 40, (int)Position.Y + 30, (int)widthOfFrame - 60, (int)heightOfFrame - 40);
    }
 }

