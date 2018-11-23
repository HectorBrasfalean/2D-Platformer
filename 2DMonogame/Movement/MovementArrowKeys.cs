﻿using _2DMonogame.Collision;
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
        public override void Update(IMovingCollide hero)
        {
            ReadButtonInput(hero);
            if (hero.Velocity.Y != 0)
            {
                hero.ChangeVelocity(null, hero.Velocity.Y + 0.2f);
            }
            hero.Position += hero.Velocity;
            if (!hero.TouchingGround && hero.Velocity.Y == 0)
            {
                hero.ChangeVelocity(null, 0.2f);
            }
        }

        private void ReadButtonInput(IMovingCollide hero)
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyUp(Keys.Right))
            {
                Right = false;
                hero.ChangeVelocity(0, null);
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Left = false;
                hero.ChangeVelocity(0, null);
            }
            if (stateKey.IsKeyDown(Keys.Left) && Right != true)
            {
                Left = true;
                hero.ChangeVelocity(-movementSpeed, null);
            }
            if (stateKey.IsKeyDown(Keys.Up) && hero.Velocity.Y == 0)
            {
                hero.ChangeVelocity(null, -8);
                Jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                Jump = false;
            }
            if (stateKey.IsKeyDown(Keys.Space))
            {
                Attack = true;
            }
            if (stateKey.IsKeyUp(Keys.Space))
            {
                Attack = false;
            }
            if (stateKey.IsKeyDown(Keys.Right) && Left != true)
            {
                Right = true;
                hero.ChangeVelocity(movementSpeed, null);
            }
        }
    }
}
