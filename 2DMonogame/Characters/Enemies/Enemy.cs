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
        public int AmountOfHitsEnemyCanTake { get; protected set; }
        public bool IsLookingLeft,Death,TouchedHero,Attack;
        private Vector2 position;
        private Vector2 velocity;
        public Animation RunAnimation, AttackAnimation, DeathAnimation, HurtAnimation, CurrentAnimation;
        protected double widthOfFrame;
        protected double heightOfFrame;

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

        public abstract Rectangle CollisionRectangle { get; }

        public IMovingCollide CurrentCollisionBlock { get; set; }

        /// <summary>
        /// Verandert de positie van de enemy
        /// </summary>
        /// <param name="x">de positie op de x-as, kan ook null zijn</param>
        /// <param name="y">de positie op de y-as, kan ook null zijn</param>
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
        /// <param name="x">de velocity op de x-as, kan ook null zijn</param>
        /// <param name="y">de velocity op de y-as, kan ook null zijn</param>
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
        /// <param name="gameTime">GameTime object die we kunnen gebruiken om de tijd te meten</param>
        /// <param name="collider">Collider object dat we gebruiken of er collision gebeurt bij de enemy</param>
        /// <param name="collisionObjects">Lijst met alle objecten die kunnen colliden</param>
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
                AmountOfHitsEnemyCanTake--;
                IsHit = false;
                ChangeVelocity(0, null);
                if(AmountOfHitsEnemyCanTake <= 0)
                    CurrentAnimation = DeathAnimation;
                else CurrentAnimation = HurtAnimation;
            }
            if (HurtAnimation != null && CurrentAnimation.CurrentFrame == HurtAnimation.frames[HurtAnimation.frames.Count - 1])
            {
                CurrentAnimation = RunAnimation;
                if (IsLookingLeft)
                    ChangeVelocity(-MovingSpeed, null);
                else ChangeVelocity(MovingSpeed, null);
                HurtAnimation.Reset();
            }
            if (Attack)
            {
                CurrentAnimation = AttackAnimation;
                ChangeVelocity(0,null);
                if (CurrentAnimation.CurrentFrame == AttackAnimation.frames[AttackAnimation.frames.Count - 1])
                {
                    Attack = false;
                    CurrentAnimation = RunAnimation;
                    if (IsLookingLeft)
                        ChangeVelocity(-MovingSpeed, null);
                    else ChangeVelocity(MovingSpeed, null);
                }
                 
            }
            else
            {
                AttackAnimation.Reset();
            }
            Position += Velocity;
            if (CurrentAnimation.CurrentFrame == DeathAnimation.frames[DeathAnimation.frames.Count - 1])
                collisionObjects.Remove(this);
            widthOfFrame = CurrentAnimation.CurrentFrame.scale * CurrentAnimation.CurrentFrame.RectangleSelector.Width;
            heightOfFrame = CurrentAnimation.CurrentFrame.scale * CurrentAnimation.CurrentFrame.RectangleSelector.Height;
            CurrentAnimation.Update(gameTime);
        }

        /// <summary>
        /// Tekent de enemy
        /// </summary>
        /// <param name="sprite">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        public override void Draw(SpriteBatch sprite)
        {
            if (Death == false && !(CurrentAnimation == DeathAnimation && CurrentAnimation.CurrentFrame == DeathAnimation.frames[DeathAnimation.frames.Count - 1]))
            {
                sprite.Draw(Texture, Position, CurrentAnimation.CurrentFrame.RectangleSelector, Color.AliceBlue, 0f, Vector2.Zero, CurrentAnimation.CurrentFrame.scale, IsLookingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            }
            else Death = true;

        }
    }
}
