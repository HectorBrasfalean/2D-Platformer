using _2DMonogame.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Characters
{
    class GreenGoblin : Enemy
    {
        public GreenGoblin(ContentManager content, string name) : base(content,name)
        {
            DeathAnimation = new GreenGoblinDeathAnimation();
            RunAnimation = new GreenGoblinRunAnimation();
            AttackAnimation = new GreenGoblinAttackAnimation();
            CurrentAnimation = RunAnimation;
            AmountOfHitsEnemyCanTake = 1;
        }

        public override float MovingSpeed => 2;
    }
}
