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
  
    class Hero : CollisionObject
    {
        public bool HasShot = false;
        public bool isLookingLeft,TouchingGround;
        public Animation idleAnimation,runAnimation,attackAnimation,jumpAnimation,deathAnimation,currentAnimation;
        public Projectile Fireball;
        public Movement movement;
        public Vector2 Velocity;
        public float FireballDelay;
        public List<Fireball> FireballList;

        public Hero(ContentManager content, Vector2 startPositionHero, Movement movement)
        {
            FireballList = new List<Fireball>();
            FireballDelay = 65;
            this.Texture = content.Load<Texture2D>("HeroSprite");
            Position = startPositionHero;
            this.movement = movement;
            Fireball = new Fireball();
            currentAnimation = new HeroIdleAnimation();
            idleAnimation = new HeroIdleAnimation();
            runAnimation = new HeroRunAnimation();
            jumpAnimation = new HeroJumpAnimation();
            attackAnimation = new HeroAttackAnimation();
            deathAnimation = new HeroDeathAnimation();
            Fireball.Texture = content.Load<Texture2D>("fireball_0");
        }

        public void Update(GameTime gameTime,List<CollisionObject> collisionObjects)
        {
            CollisionRectangle = new Rectangle((int)Position.X+10, (int)Position.Y+25, 80, 60);
            CollisionDetect(collisionObjects,this);
            currentAnimation.Update(gameTime, this);
            movement.Update(this);
            if (movement.Attack)
                Shoot();
            if (!movement.Attack)
                FireballDelay = 65;
            foreach (Fireball ball in FireballList)
            {
                ball.Update(gameTime);
            }

        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
             spriteBatch.Draw(Texture, Position, currentAnimation.CurrentFrame.RectangleSelector, Color.AliceBlue, 0f, Vector2.Zero, currentAnimation.CurrentFrame.scale, isLookingLeft?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f);
            foreach (Fireball ball in FireballList)
            {
                ball.Draw(spriteBatch);
            }
        }

        public void Shoot()
        {
            if (HasShot)
                FireballDelay--;
            if (HasShot != true && currentAnimation.CurrentFrame == currentAnimation.frames[4])
            {
                HasShot = true;
                Fireball fireBall = new Fireball() { Texture = Fireball.Texture };
                fireBall.Position = new Vector2(Position.X + 102, Position.Y + 30);
                fireBall.IsVisible = true;
                
                if(FireballList.Count() < 20)
                {
                    FireballList.Add(fireBall);
                }
            }
            if(FireballDelay == 0)
            {
                HasShot = false;
                FireballDelay = 65;
            }
        }
    }
}
