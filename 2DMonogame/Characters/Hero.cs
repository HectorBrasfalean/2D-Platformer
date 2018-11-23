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
  
    class Hero : IMovingCollide
    {
        public bool HasShot = false;
        public bool isLookingLeft,PositionHasChanged;
        public Animation idleAnimation,runAnimation,attackAnimation,jumpAnimation,deathAnimation,currentAnimation;
        public Texture2D Texture;
        public Projectile Fireball;
        public Movement movement;
        public float FireballDelay;
        public List<Fireball> FireballList;

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

        public Hero(ContentManager content, Vector2 startPositionHero, Movement movement)
        {
            FireballList = new List<Fireball>();
            FireballDelay = 65;
            this.Texture = content.Load<Texture2D>("HeroSprite");
            Position = startPositionHero;
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
        public void Update(GameTime gameTime,List<ICollide> collisionObjects)
        {
            CheckWhichAnimation();
            movement.Update(this);
            if (movement.Attack)
                Shoot();
            if (!movement.Attack)
                FireballDelay = 65;
            foreach (Fireball ball in FireballList)
            {
                ball.Update(gameTime);
            }
            currentAnimation.Update(gameTime);
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
            
        }
 
        /// <summary>
        /// Tekent de hero op het scherm
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
             spriteBatch.Draw(Texture, Position, currentAnimation.CurrentFrame.RectangleSelector, Color.AliceBlue, 0f, Vector2.Zero, currentAnimation.CurrentFrame.scale, isLookingLeft?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f);
            foreach (Fireball ball in FireballList)
            {
                ball.Draw(spriteBatch);
            }
        }
        /// <summary>
        /// Laat de hero schieten
        /// </summary>
        public void Shoot()
        {
            if (HasShot)
                FireballDelay--;
            if (HasShot != true && currentAnimation.CurrentFrame == currentAnimation.frames[4])
            {
                HasShot = true;
                Fireball fireBall = new Fireball() { Texture = Fireball.Texture };
                fireBall.Position = new Vector2(Position.X + 72, Position.Y + 30);
                fireBall.IsVisible = true;
    
                FireballList.Add(fireBall);
            }
            if(FireballDelay == 0)
            {
                HasShot = false;
                FireballDelay = 65;
            }
        }

        
    }
}
