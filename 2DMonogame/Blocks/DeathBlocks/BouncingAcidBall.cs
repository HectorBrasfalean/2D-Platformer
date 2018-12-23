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
        Animation currentAnimation;
        Animation flyingAcidBallAnimation;

        public IMovingCollide CurrentCollisionBlock { get; set; }

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

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, currentAnimation.CurrentFrame.RectangleSelector.Width, currentAnimation.CurrentFrame.RectangleSelector.Height);

        public BouncingAcidBall(ContentManager content, string name) : base(content, name)
        {
            flyingAcidBallAnimation = new GreenAcidBallDownUpAnimation();
            currentAnimation = flyingAcidBallAnimation;
            ChangeVelocity(null, bounceHeight);
        }

        /// <summary>
        /// Update de bouncing acid ball
        /// </summary>
        /// <param name="gameTime">GameTime object waarmee een kunnen kijken hoeveel tijd er al voorbij is gegaan</param>
        /// <param name="collider">Collider die kijkt of er een collision gebeurt bij de acid ball</param>
        /// <param name="collisionObjects">Lijst met alle objecten die kunnen colliden</param>
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
            currentAnimation.Update(gameTime);
        }

        /// <summary>
        /// Tekent de acid ball
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, currentAnimation.CurrentFrame.RectangleSelector, Color.LightGreen,0f, Vector2.Zero, currentAnimation.CurrentFrame.scale, isGoingDown ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Hiermee passen we de velocity van de acid ball aan
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
        /// Hiermee passen we de positie van de acid ball aan
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
    }
}
