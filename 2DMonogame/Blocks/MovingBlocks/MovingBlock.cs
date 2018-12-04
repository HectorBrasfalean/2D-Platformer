using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DMonogame.Blocks.MovingBlocks
{
    /// <summary>
    /// Verantwoordelijk voor de bewegende blokken
    /// </summary>
    class MovingBlock : StaticBlock, IMoveBlock
    {
        public bool Invert;
        public MovingBlock(ContentManager content, string name) : base(content, name)
        {
            velocity.X = MovingSpeed;
        }
        public float MovingSpeed => 3;
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
        private Vector2 position;
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingGround { get; set; }
        public bool TouchingTop { get; set; }
        public IMovingCollide currentCollisionBlock { get; set; }
        public bool HasTouchedCollectable { get; set; }

        /// <summary>
        /// Verandert de positie
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
        /// Verandert de velocity
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
        /// Update de bewegende blok
        /// </summary>
        /// <param name="collisionObjects"></param>
        /// <param name="collider"></param>
        public void Update(List<ICollide> collisionObjects,Collider collider)
        {
            collider.CollisionDetect(collisionObjects,(IMovingCollide) this);
            if (currentCollisionBlock is IMoveBlock)
            {
                currentCollisionBlock.ChangeVelocity(-velocity.X, null);
            }
            if (TouchingLeft || TouchingRight || Invert)
            {
                ChangeVelocity(-velocity.X, null);
                Invert = false;
            }
            Position += velocity;
        }

        /// <summary>
        /// Tekent de bewegende blok
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
