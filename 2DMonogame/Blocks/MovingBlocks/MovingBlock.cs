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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
