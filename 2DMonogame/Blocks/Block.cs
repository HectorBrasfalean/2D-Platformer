using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Content;

namespace _2DMonogame
{
    abstract class Block : CollisionObject
    {
        
        public Block(ContentManager content,string name)
        {
            Texture = content.Load<Texture2D>(name);
        }
        public void Initialize(Vector2 position,List<CollisionObject> collisionObjects)
        {
            Position = position;
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            collisionObjects.Add(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position,Color.AliceBlue);
        }

    }
}
