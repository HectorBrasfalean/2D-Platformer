using _2DMonogame.Blocks;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de bewegingen met pijltjestoetsen
    /// </summary>
    class MovementArrowKeys : Movement
    {
        /// <summary>
        /// Update de movement voor een bewegend collision object
        /// </summary>
        /// <param name="movingCollision">bewegend object dat kan colliden</param>
        public override void Update(IMovingCollide movingCollision)
        {
            if (movingCollision.TouchingGround)
                movingCollision.ChangeVelocity(null, 0);
            if (movingCollision.TouchingLeft)
            {
                if(movingCollision.CurrentCollisionBlock is IMoveBlock)
                    movingCollision.ChangePosition(movingCollision.Position.X + movingCollision.MovingSpeed + movingCollision.CurrentCollisionBlock.MovingSpeed, null);
                else
                    movingCollision.ChangePosition(movingCollision.Position.X + movingCollision.MovingSpeed, null);
                movingCollision.ChangeVelocity(0, null);
            }
            if(movingCollision.TouchingRight)
            {
                if (movingCollision.CurrentCollisionBlock is IMoveBlock)
                    movingCollision.ChangePosition(movingCollision.Position.X - movingCollision.MovingSpeed - movingCollision.CurrentCollisionBlock.MovingSpeed, null);
                else
                    movingCollision.ChangePosition(movingCollision.Position.X - movingCollision.MovingSpeed, null);
               movingCollision.ChangeVelocity(0, null);
        
            }
            if (movingCollision.TouchingTop)
                movingCollision.ChangeVelocity(null, 0.1f);
            ReadButtonInput(movingCollision);
            if (movingCollision.Velocity.Y != 0)
            {
                movingCollision.ChangeVelocity(null, movingCollision.Velocity.Y + 0.2f);
            }
            movingCollision.Position += movingCollision.Velocity;
            if (!movingCollision.TouchingGround && movingCollision.Velocity.Y == 0)
            {
                movingCollision.ChangeVelocity(null, 0.2f);
            }

        }

        /// <summary>
        /// Leest de input van de ingedrukte knoppen
        /// </summary>
        /// <param name="movingCollide">het bewegend collision object</param>
        private void ReadButtonInput(IMovingCollide movingCollide)
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyUp(Keys.Right))
            {
                Right = false;
                movingCollide.ChangeVelocity(0, null);
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Left = false;
                movingCollide.ChangeVelocity(0, null);
            }
            if (stateKey.IsKeyDown(Keys.Left) && Right != true)
            {
                Left = true;
                movingCollide.ChangeVelocity(-movementSpeed, null);
            }
            if (stateKey.IsKeyDown(Keys.Up) && movingCollide.Velocity.Y == 0)
            {
                movingCollide.ChangeVelocity(null, -8);
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
                movingCollide.ChangeVelocity(movementSpeed, null);
            }
        }
    }
}
