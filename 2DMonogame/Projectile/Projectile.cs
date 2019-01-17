using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor elk projectiel
    /// </summary>
    abstract class Projectile : IMovingCollide
    {
        public Texture2D Texture;
        public float speed,ShotStartPosition;
        public bool IsVisible,GoesLeft;
        private Vector2 velocity;
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingGround { get; set; }
        public bool TouchingTop { get; set; }
        public Vector2 Position { get; set; }
        private Vector2 position;
        public Rectangle CollisionRectangle { get { return new Rectangle((int)Position.X, (int)Position.Y, 60, 42); } }

        public float MovingSpeed { get { return 5; } }

        public IMovingCollide CurrentCollisionBlock { get; set; }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch sprite);

        /// <summary>
        /// Verandert de velocity van het projectiel
        /// </summary>
        /// <param name="x">Velocity op de x-as, kan ook null zijn</param>
        /// <param name="y">Velocity op de y-as, kan ook null zijn</param>
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

        /// <summary>
        /// Verandert de positie van het projectiel
        /// </summary>
        /// <param name="x">Positie op de x-as, kan ook null zijn</param>
        /// <param name="y">Positie op de y-as, kan ook null zijn</param>
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
    }
}
