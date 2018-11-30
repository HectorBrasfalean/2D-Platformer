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
        public GreenGoblin(ContentManager content, Vector2 startPositionEnemy) : base(content,startPositionEnemy)
        {
            Texture = content.Load<Texture2D>("GreenGoblinSprite");
            DeathAnimation = new GreenGoblinDeathAnimation();
            RunAnimation = new GreenGoblinRunAnimation();
            AttackAnimation = new GreenGoblinAttackAnimation();
            currentAnimation = RunAnimation;
        }
    }
}
