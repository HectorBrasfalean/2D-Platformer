using _2DMonogame.Characters;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
  /// <summary>
  /// Verantwoordelijk voor het gedrag van het hero object
  /// </summary>
    class Hero : IMovingCollide,IDie,ICanCollect
    {
        public bool isLookingLeft,HasShot;
        public int amountOfStarsCollected;
        public Vector2 RespawnLocation;
        public Animation idleAnimation,runAnimation,attackAnimation,jumpAnimation,deathAnimation,currentAnimation;
        public Texture2D Texture;
        public Projectile Fireball;
        public Movement movement;
        public List<Projectile> fireballs;

        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X + 10, (int)Position.Y + 25, 80, 60); }
        }

        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingTop { get; set; }

        private Vector2 velocity;

        public Vector2 Velocity {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
        /// <summary>
        /// Past de velocity aan van het hero object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ChangeVelocity(float? x, float? y)
        {
            if (x != null) {
                velocity.X = (float)x;
            }
            if (y != null)
            {
                velocity.Y= (float)y;
            }

        }
        /// <summary>
        /// Past de positie aan van het hero object
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
        public bool TouchingGround { get; set; }
        public float MovingSpeed { get { return movement.movementSpeed; }  }

        public IMovingCollide currentCollisionBlock { get; set; }
        public bool HasTouchedCollectable { get; set; }
        public bool IsHit { get; set; }
        private int amountOfLives = 3;

        public int AmountOfLives
        {
            get { return amountOfLives; }
            private set { amountOfLives = value; }
        }

        public Hero(ContentManager content, Vector2 startPositionHero, Movement movement)
        {
            fireballs = new List<Projectile>();
            this.Texture = content.Load<Texture2D>("HeroSprite");
            Position = startPositionHero;
            RespawnLocation = startPositionHero;
            this.movement = movement;
            Fireball = new Fireball();

            idleAnimation = new HeroIdleAnimation();
            currentAnimation = idleAnimation;
            runAnimation = new HeroRunAnimation();
            jumpAnimation = new HeroJumpAnimation();
            attackAnimation = new HeroAttackAnimation();
            deathAnimation = new HeroDeathAnimation();
            Fireball.Texture = content.Load<Texture2D>("fireball_0");
        }
        /// <summary>
        /// Update het hero object
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="collisionObjects"></param>
        public void Update(GameTime gameTime,List<ICollide> collisionObjects,Collider collisionCheck)
        {
            if (!IsHit)
            {
                collisionCheck.CollisionDetect(collisionObjects, this);
                CheckWhichAnimation();
                movement.Update(this);
                if (HasTouchedCollectable)
                {
                    amountOfStarsCollected++;
                    HasTouchedCollectable = false;
                }
                if (movement.Attack)
                    Shoot();
                UpdateAllFireballs(gameTime, collisionObjects, collisionCheck);
                currentAnimation.Update(gameTime);
            }
            else
                SetHeroDeathAnimation(gameTime);
        }

        /// <summary>
        /// Update alle fireballs
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="collisionObjects"></param>
        /// <param name="collisionCheck"></param>
        private void UpdateAllFireballs(GameTime gameTime, List<ICollide> collisionObjects, Collider collisionCheck)
        {
            foreach (Projectile ball in fireballs.ToList())
            {
                collisionCheck.CollisionDetect(collisionObjects, ball);
                if (ball.Position.X > Position.X + 500 || ball.Position.X < Position.X - 500 || ball.TouchingRight || ball.TouchingLeft)
                    fireballs.Remove(ball);
                ball.Update(gameTime);
            }
        }

        /// <summary>
        /// Zet de hero deathanimation als de momentele animation
        /// </summary>
        /// <param name="gameTime"></param>
        private void SetHeroDeathAnimation(GameTime gameTime)
        {
            currentAnimation = deathAnimation;
            if (currentAnimation.CurrentFrame != deathAnimation.frames[deathAnimation.frames.Count - 1])
            {
                currentAnimation.Update(gameTime);
            }
            else
            {
                CheckIfDeath();
            }

        }

        /// <summary>
        /// Controleert of de hero dood is
        /// </summary>
        private void CheckIfDeath()
        {
            if (amountOfLives > 0)
            {
                amountOfLives--;
                IsHit = false;
                Position = RespawnLocation;
            }
        }

        /// <summary>
        /// Laat de hero schieten
        /// </summary>
        private void Shoot()
        {
            if (HasShot != true && currentAnimation.CurrentFrame == attackAnimation.frames[attackAnimation.frames.Count - 1])
            {
                HasShot = true;
                Projectile fireBall = new Fireball() { Texture = Fireball.Texture };
                fireBall.GoesLeft = isLookingLeft;
                fireBall.Position = new Vector2(fireBall.GoesLeft?Position.X-10:Position.X+72, Position.Y + 30);
                fireBall.IsVisible = true;
                fireballs.Add(fireBall);
            }
            if (currentAnimation.CurrentFrame != attackAnimation.frames[attackAnimation.frames.Count - 1] && currentAnimation == attackAnimation)
            {
                HasShot = false;
            }
        }
        /// <summary>
        /// Controleert welke animatie we momenteel moeten afspelen
        /// </summary>
        private void CheckWhichAnimation()
        {
            if (movement.Jump)
            {
                if (Velocity.X > 0)
                    isLookingLeft = false;
                if (Velocity.X < 0)
                    isLookingLeft = true;
                currentAnimation = jumpAnimation;
            }
            else if (movement.Right)
            {
                isLookingLeft = false;
                if (Velocity.Y == 0)
                    currentAnimation = runAnimation;
            }
            else if (movement.Left)
            {
                isLookingLeft = true;
                if (Velocity.Y == 0)
                    currentAnimation = runAnimation;
            }
            else if (movement.Attack && Velocity.Y == 0)
            {
                currentAnimation = attackAnimation;
            }
            else
            {
                if(Velocity.Y == 0)
                currentAnimation = idleAnimation;
            }
            deathAnimation.Reset();
        }
 
        /// <summary>
        /// Tekent de hero op het scherm
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, currentAnimation.CurrentFrame.RectangleSelector, Color.AliceBlue, 0f, Vector2.Zero, currentAnimation.CurrentFrame.scale, isLookingLeft?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f);
            foreach (Projectile ball in fireballs)
            {
                ball.Draw(spriteBatch);
            }

        }

  

        
    }
}
