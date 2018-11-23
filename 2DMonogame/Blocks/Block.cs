using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Content;
using _2DMonogame.Collision;

namespace _2DMonogame
{
    abstract class Block : ICollide
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture;
        public Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        public Block(ContentManager content,string name)
        {
            Texture = content.Load<Texture2D>(name);
        }
        public void Initialize(Vector2 position,List<ICollide> collisionObjects)
        {
            Position = position;
            collisionObjects.Add(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position,Color.AliceBlue);
        }

    }
}
