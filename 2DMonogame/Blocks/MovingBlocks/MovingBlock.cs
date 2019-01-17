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
    /// Verantwoordelijk voor elke bewegende blok
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
        public IMovingCollide CurrentCollisionBlock { get; set; }
        public bool HasTouchedCollectable { get; set; }

        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        /// <summary>
        /// Verandert de positie
        /// </summary>
        /// <param name="x">Het aanpassen van de positie op de x-as, kan ook null zijn</param>
        /// <param name="y">Het aanpassen van de positie op de y-as, kan ook null zijn</param>
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
        /// <param name="x">Het aanpassen van de velocity op de x-as, kan ook null zijn</param>
        /// <param name="y">Het aanpassen van de velocity op de y-as, kan ook null zijn</param>
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
        /// <param name="collisionObjects">Lijst met alle objecten die kunnen colliden</param>
        /// <param name="collider">Collider die kijkt of er collision gebeurt met de bewegende blok</param>
        public void Update(List<ICollide> collisionObjects,Collider collider)
        {
            collider.CollisionDetect(collisionObjects,this);
            if (CurrentCollisionBlock is IMoveBlock)
            {
                CurrentCollisionBlock.ChangeVelocity(-velocity.X, null);
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
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
