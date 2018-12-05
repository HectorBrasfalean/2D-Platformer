using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Animations.Projectile;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DMonogame.Blocks.DeathBlocks
{
    class BouncingAcidBall : StaticBlock,IDeathBlock,IMovingCollide
    {
        bool isGoingDown;
        float bounceHeight = -13f;
        private Vector2 velocity;
        private Vector2 position;
        Animation CurrentAnimation;
        Animation flyingAcidBallAnimation;

        public IMovingCollide currentCollisionBlock { get; set; }

        public float MovingSpeed =>0.15f;

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

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, CurrentAnimation.CurrentFrame.RectangleSelector.Width, CurrentAnimation.CurrentFrame.RectangleSelector.Height);

        public BouncingAcidBall(ContentManager content, string name) : base(content, name)
        {
            flyingAcidBallAnimation = new GreenAcidBallDownUpAnimation();
            CurrentAnimation = flyingAcidBallAnimation;
            ChangeVelocity(null, bounceHeight);
        }
        public void Update(GameTime gameTime,Collider collider,List<ICollide> collisionObjects)
        {
            collider.CollisionDetect(collisionObjects, this);
            if (TouchingGround)
            {
                isGoingDown = false;
                ChangeVelocity(null, bounceHeight);
            }
            if (Velocity.Y > 0)
                isGoingDown = true;
            if (Velocity.Y != 0)
                ChangeVelocity(null, Velocity.Y + MovingSpeed);
            Position += velocity;
            CurrentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, CurrentAnimation.CurrentFrame.RectangleSelector, Color.LightGreen,0f, Vector2.Zero, CurrentAnimation.CurrentFrame.scale, isGoingDown ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
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
