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
    /// <summary>
    /// Verantwoordelijk voor de groene goblin enemy
    /// </summary>
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

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X + 40, (int)Position.Y + 30, (int)widthOfFrame - 60, (int)heightOfFrame - 40);
    }
}
