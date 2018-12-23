using _2DMonogame.Blocks;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Button
{
    /// <summary>
    /// Verantwoordelijk voor de knop die je naar het volgende level brengt
    /// </summary>
    class ButtonNextLevel : GameObject,ICollide
    {
        public ButtonNextLevel(ContentManager content, string name) : base(content, name)
        {

        }

        public Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        /// <summary>
        /// Tekent de knop waar we op springen om naar het volgende level te gaan
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
    }
}
