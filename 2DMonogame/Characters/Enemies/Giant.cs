using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Animations;
using _2DMonogame.Animations.Giant;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DMonogame.Characters
{
    class Giant : Enemy
    {
        public Giant(ContentManager content, string name) : base(content, name)
        {
            AttackAnimation = new GiantAttackAnimation();
            RunAnimation = new GiantRunAnimation();
            DeathAnimation = new GiantDieAnimation();
            HurtAnimation = new GiantHurtAnimation();
            CurrentAnimation = RunAnimation;
            AmountOfHitsEnemyCanTake = 3;
        }

        public override float MovingSpeed => 1f;

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X+30, (int)Position.Y + 30, (int)widthOfFrame -60, (int)heightOfFrame - 40);
    }
}
