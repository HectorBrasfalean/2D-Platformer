using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    class MovementArrowKeys : Movement
    {

        
        public override void Update(Hero hero)
        {

            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyUp(Keys.Right))
            {
                if(Right == true)
                    hero.currentAnimation.Reset();
                Right = false;
                hero.Velocity.X = 0;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                if (Left == true)
                    hero.currentAnimation.Reset();
                Left = false;
                hero.Velocity.X = 0;
            }
            if (stateKey.IsKeyDown(Keys.Left) && Right != true )
            {
                Left = true;
                hero.Velocity.X = -movementSpeed;
            }
            if (hero.currentAnimation == hero.jumpAnimation && hero.Velocity.Y == 0) ////////////////////////////////////////////////////
            {
                hero.currentAnimation.Reset();
            }
            if (stateKey.IsKeyDown(Keys.Up) && hero.Velocity.Y == 0)
            {
                hero.Velocity.Y = -8f;
                Jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                Jump = false;
            }
            if(stateKey.IsKeyDown(Keys.Down))
            {
                hero.currentAnimation = hero.deathAnimation;
            }
            if (stateKey.IsKeyDown(Keys.Space))
            {
                Attack = true;
            }
            if (stateKey.IsKeyUp(Keys.Space))
            {
                if (Attack == true)
                    hero.currentAnimation.Reset();
                Attack = false;
            }
            if (stateKey.IsKeyDown(Keys.Right) && Left != true )
            {
                Right = true;
                hero.Velocity.X = movementSpeed;
            }
            if (hero.Velocity.Y != 0)
            {
                hero.Velocity.Y += 0.2f;
            }
            hero.Position += hero.Velocity;
            if (!hero.TouchingGround && hero.Velocity.Y == 0)
            {
                hero.Velocity.Y = 0.2f;
            }
        }
    }
}
