using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Animations.Orc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DMonogame.Characters
{
    /// <summary>
    /// Verantwoordelijk voor de orc enemy
    /// </summary>
    class Orc : Enemy
    {
        public Orc(ContentManager content,string name) : base(content, name)
        {
            RunAnimation = new OrcRunAnimation();
            DeathAnimation = new OrcDieAnimation();
            AttackAnimation = new OrcAttackAnimation();
            CurrentAnimation = RunAnimation;
        }

        public override float MovingSpeed => 1.5f;

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X + 30, (int)Position.Y + 30, (int)widthOfFrame - 60, (int)heightOfFrame - 40);
    }
}
