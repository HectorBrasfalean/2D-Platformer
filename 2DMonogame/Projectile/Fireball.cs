using _2DMonogame.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    class Fireball : Projectile
    {
        Animation fireballAnimation;
        public Fireball()
        {
            
            speed = 5;
            IsVisible = false;
            fireballAnimation = new FireballAnimation();
        }

        public override void Draw(SpriteBatch sprite)
        {
            sprite.Draw(Texture, Position,fireballAnimation.CurrentFrame.RectangleSelector, Color.AliceBlue);
        }

        public override void Update(GameTime gameTime)
        {
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 72, 42);
            fireballAnimation.Update(gameTime);
            Position.X += speed;
        }
    }
}
