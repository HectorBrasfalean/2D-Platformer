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
    abstract class Block
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture;
        public Block(ContentManager content, string name)
        {
            Texture = content.Load<Texture2D>(name);
        }
        public void Initialize(Vector2 position)
        {
            Position = position;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
