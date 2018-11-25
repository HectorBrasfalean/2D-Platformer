using _2DMonogame.Collision;
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
    abstract class Enemy : IMovingCollide
    {
        private Vector2 position;
        private Vector2 velocity;
        public Texture2D Texture;
        public Animation RunAnimation;
        public Animation AttackAnimation;
        public Animation DeathAnimation;
        public Enemy(ContentManager content, Vector2 startPositionEnemy)
        {
            Position = startPositionEnemy;
        }
        public Vector2 Position { get; set; }

        public float MovingSpeed => 6;

        public Vector2 Velocity { get; set; }
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingGround { get; set; }
        public bool TouchingTop { get; set; }

        public Rectangle CollisionRectangle => new Rectangle((int)Position.X,(int)Position.Y,Texture.Width,Texture.Height);

        public void ChangePosition(float? x, float? y)
        {
            if (x != null)
            {
                position.X = (float)x;
            }
            if (y != null)
            {
                position.Y = (float)y;
            }
        }

        public void ChangeVelocity(float? x, float? y)
        {
            if (x != null)
            {
                velocity.X = (float)x;
            }
            if (y != null)
            {
                velocity.Y = (float)y;
            }
        }
    }
}
