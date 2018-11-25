using _2DMonogame.Animations;
using _2DMonogame.Collision;
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
    /// <summary>
    /// Verantwoordelijk voor het fireball object 
    /// </summary>
    class Fireball : Projectile
    {
        Animation fireballAnimation;
        public Fireball()
        {
            speed = 5;
            IsVisible = false;
            fireballAnimation = new FireballAnimation();
        }

        /// <summary>
        /// Tekent de fireball op het scherm
        /// </summary>
        /// <param name="sprite"></param>
        public override void Draw(SpriteBatch sprite)
        {
            sprite.Draw(Texture,Position,fireballAnimation.CurrentFrame.RectangleSelector,Color.AliceBlue,0f,Vector2.Zero,1f,GoesLeft?SpriteEffects.FlipHorizontally:SpriteEffects.None,0);
        }


        /// <summary>
        /// Update de positie van de fireball
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            fireballAnimation.Update(gameTime);
            ChangeVelocity(GoesLeft?-speed:speed, null);
            Position += Velocity;
        }
    }
}
