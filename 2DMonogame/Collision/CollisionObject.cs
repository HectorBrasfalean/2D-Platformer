using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    abstract class CollisionObject
    {
        public Vector2 Position;
        public Texture2D Texture;
        private Rectangle collisionRectangle;
        
        public Rectangle CollisionRectangle
        {
            get
            {
                return collisionRectangle;
            }
            protected set { collisionRectangle = value; }
        }

        private bool IsTouchingLeft(CollisionObject sprite,Hero hero)
        {
            return hero.CollisionRectangle.Right + hero.Velocity.X > sprite.CollisionRectangle.Left &&
              hero.CollisionRectangle.Left < sprite.CollisionRectangle.Left &&
              hero.CollisionRectangle.Bottom > sprite.CollisionRectangle.Top &&
              hero.CollisionRectangle.Top < sprite.CollisionRectangle.Bottom;
        }

        private bool IsTouchingRight(CollisionObject sprite,Hero hero)
        {
            return hero.CollisionRectangle.Left + hero.Velocity.X < sprite.CollisionRectangle.Right &&
              hero.CollisionRectangle.Right > sprite.CollisionRectangle.Right &&
              hero.CollisionRectangle.Bottom > sprite.CollisionRectangle.Top &&
              hero.CollisionRectangle.Top < sprite.CollisionRectangle.Bottom;
        }

        private bool IsTouchingTop(CollisionObject sprite,Hero hero)
        {
            return hero.CollisionRectangle.Bottom + hero.Velocity.Y > sprite.CollisionRectangle.Top &&
              hero.CollisionRectangle.Top < sprite.CollisionRectangle.Top &&
              hero.CollisionRectangle.Right > sprite.CollisionRectangle.Left &&
              hero.CollisionRectangle.Left < sprite.CollisionRectangle.Right;
        }

        private bool IsTouchingBottom(CollisionObject sprite,Hero hero)
        {
            return hero.CollisionRectangle.Top + hero.Velocity.Y < sprite.CollisionRectangle.Bottom &&
              hero.CollisionRectangle.Bottom > sprite.CollisionRectangle.Bottom &&
              hero.CollisionRectangle.Right > sprite.CollisionRectangle.Left &&
              hero.CollisionRectangle.Left < sprite.CollisionRectangle.Right;
        }
        public void CollisionDetect(List<CollisionObject> collideObjects, Hero hero)
        {
            // if(this is Hero){
            // }
            // if(this is Enemy){
            // }
            // if(this is Projectile){
            // }
            foreach (var currentObject in collideObjects.OfType<Block>())
            {
                hero.TouchingGround = false;
                if (hero.Velocity.X > 0 && hero.IsTouchingLeft(currentObject,hero)){
                    hero.Position.X -= hero.movement.movementSpeed;
                    hero.Velocity.X = 0;
                }

                if (hero.Velocity.X < 0 && hero.IsTouchingRight(currentObject,hero))
                {
                    hero.Position.X += hero.movement.movementSpeed;
                    hero.Velocity.X = 0;
                }
                if (hero.Velocity.Y > 0 && hero.IsTouchingTop(currentObject,hero))
                {
                    hero.Velocity.Y = 0;
                    hero.TouchingGround = true;
                }

                if (hero.Velocity.Y < 0 && hero.IsTouchingBottom(currentObject,hero))
                {
                    hero.Velocity.Y = 0.01f;
                }
            }
        }
    }
}
