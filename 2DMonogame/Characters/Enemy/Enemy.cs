using _2DMonogame.Blocks;
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
    /// <summary>
    /// Verantwoordelijk voor elke handeling van de enemy
    /// </summary>
    abstract class Enemy : GameObject,IMovingCollide,IDie
    {
        public bool IsLookingLeft,Death,TouchedHero,Attack;
        private Vector2 position;
        private Vector2 velocity;
        public Animation RunAnimation;
        public Animation AttackAnimation;
        public Animation DeathAnimation;
        public Animation currentAnimation;
        public Enemy(ContentManager content,string name) : base(content,name)
        {
            ChangeVelocity(null, Velocity.Y + 5f);
        }
        public abstract float MovingSpeed { get; }

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
        public bool IsHit { get; set; }

        public Rectangle CollisionRectangle => new Rectangle((int)Position.X+20,(int)Position.Y+30,currentAnimation.CurrentFrame.RectangleSelector.Width-30, currentAnimation.CurrentFrame.RectangleSelector.Height-40);

        public IMovingCollide currentCollisionBlock { get; set; }

        /// <summary>
        /// Verandert de positie van de enemy
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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

        /// <summary>
        /// Verandert de velocity van de enemy
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
        /// Update de enemy
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="collider"></param>
        /// <param name="collisionObjects"></param>
        public void Update(GameTime gameTime,Collider collider,List<ICollide> collisionObjects)
        {
            collider.CollisionDetect(collisionObjects, this);
            if (TouchingGround)
                ChangeVelocity(MovingSpeed, 0);
            if (TouchingLeft && Velocity.Y == 0)
            {
                IsLookingLeft = false;
                ChangeVelocity(MovingSpeed, null);
            }
            if (TouchingRight && Velocity.Y == 0)
            {
                IsLookingLeft = true;
                ChangeVelocity(-MovingSpeed, null);
            }
            if (IsHit)
            {
                currentAnimation = DeathAnimation;
            }
            if (Attack)
            {
                currentAnimation = AttackAnimation;
                //ChangeVelocity(0,null);
                if (currentAnimation.CurrentFrame == AttackAnimation.frames[AttackAnimation.frames.Count - 1])
                {
                    Attack = false;
                    currentAnimation = RunAnimation;
                }
                 
            }
            else
            {
                AttackAnimation.Reset();
            }
            Position += Velocity;
            if (currentAnimation.CurrentFrame == DeathAnimation.frames[DeathAnimation.frames.Count - 1])
                collisionObjects.Remove(this);
            currentAnimation.Update(gameTime);
        }

        /// <summary>
        /// Tekent de enemy
        /// </summary>
        /// <param name="sprite"></param>
        public override void Draw(SpriteBatch sprite)
        {
            if (Death == false && !(currentAnimation == DeathAnimation && currentAnimation.CurrentFrame == DeathAnimation.frames[DeathAnimation.frames.Count - 1]))
            {
                sprite.Draw(Texture, Position, currentAnimation.CurrentFrame.RectangleSelector, Color.AliceBlue, 0f, Vector2.Zero, currentAnimation.CurrentFrame.scale, IsLookingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            }
            else Death = true;

        }
    }
}
