using _2DMonogame.Blocks.Collectable;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Blocks
{
    abstract class GameObject
    {

        public Vector2 Position { get; set; }
        public Texture2D Texture;
        public GameObject(ContentManager content, string name)
        {
            Texture = content.Load<Texture2D>(name);
        }
        public void Initialize(Vector2 position)
        {
            Position = position;
        }
        public abstract void Draw(SpriteBatch spriteBatch);
       
    }
}
