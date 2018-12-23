using _2DMonogame.Blocks;
using _2DMonogame.Blocks.Collectable;
using _2DMonogame.Blocks.DeathBlocks;
using _2DMonogame.Blocks.InvisibleBlocks;
using _2DMonogame.Button;
using _2DMonogame.Characters;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de collision bij alle objecten
    /// </summary>
    class Collider
    {
        /// <summary>
        /// Controleert of we de linkerkant van de static sprite aanraken
        /// </summary>
        /// <param name="staticObject">static collision object</param>
        /// <param name="movingCollision">bewegend collision object</param>
        /// <returns>returned true als het bewegend object de linkerkant van het static object aanraakt</returns>
        private bool IsTouchingLeft(ICollide staticObject, IMovingCollide movingCollision)
        {
            return movingCollision.CollisionRectangle.Right + movingCollision.Velocity.X > staticObject.CollisionRectangle.Left &&
              movingCollision.CollisionRectangle.Left < staticObject.CollisionRectangle.Left &&
              movingCollision.CollisionRectangle.Bottom > staticObject.CollisionRectangle.Top &&
              movingCollision.CollisionRectangle.Top < staticObject.CollisionRectangle.Bottom;
        }

        /// <summary>
        /// Controleert of we de rechterkant van de static sprite aanraken
        /// </summary>
        /// <param name="staticObject">static collision object</param>
        /// <param name="movingCollision">bewegend collision object</param>
        /// <returns>returned true als het bewegend object de rechterkant van het static object aanraakt</returns>
        private bool IsTouchingRight(ICollide staticObject, IMovingCollide movingCollision)
        {
            return movingCollision.CollisionRectangle.Left + movingCollision.Velocity.X < staticObject.CollisionRectangle.Right &&
              movingCollision.CollisionRectangle.Right > staticObject.CollisionRectangle.Right &&
              movingCollision.CollisionRectangle.Bottom > staticObject.CollisionRectangle.Top &&
              movingCollision.CollisionRectangle.Top < staticObject.CollisionRectangle.Bottom;
        }
        /// <summary>
        /// Controleert of we de bovenkant raken van de static sprite
        /// </summary>
        /// <param name="staticObject">static collision object</param>
        /// <param name="movingCollision">bewegend collision object</param>
        /// <returns>returned true als het bewegend object de bovenkant van het static object aanraakt</returns>
        private bool IsTouchingTop(ICollide staticObject, IMovingCollide movingCollision)
        {
            return movingCollision.CollisionRectangle.Bottom + movingCollision.Velocity.Y > staticObject.CollisionRectangle.Top &&
              movingCollision.CollisionRectangle.Top < staticObject.CollisionRectangle.Top &&
              movingCollision.CollisionRectangle.Right > staticObject.CollisionRectangle.Left &&
              movingCollision.CollisionRectangle.Left < staticObject.CollisionRectangle.Right;
        }
        /// <summary>
        /// Controleert of we de onderkant raken van de static sprite
        /// </summary>
        /// <param name="staticObject">static collision object</param>
        /// <param name="movingCollision">bewegend collision object</param>
        /// <returns>returned true als het bewegend object de onderkant van het static object aanraakt</returns>
        private bool IsTouchingBottom(ICollide staticObject, IMovingCollide movingCollision)
        {
            return movingCollision.CollisionRectangle.Top + movingCollision.Velocity.Y < staticObject.CollisionRectangle.Bottom &&
              movingCollision.CollisionRectangle.Bottom > staticObject.CollisionRectangle.Bottom &&
              movingCollision.CollisionRectangle.Right > staticObject.CollisionRectangle.Left &&
              movingCollision.CollisionRectangle.Left < staticObject.CollisionRectangle.Right;
        }
        /// <summary>
        /// Kijkt of er een collision gebeurt
        /// </summary>
        /// <param name="collideObjects">Lijst met elk object dat kan colliden</param>
        /// <param name="movingCollision">bewegend object dat kan colliden</param>
        public void CollisionDetect(List<ICollide> collideObjects, IMovingCollide movingCollision)
        {
            ResetState(movingCollision);
            if(movingCollision is Hero)
                DetectHeroDeath(collideObjects,(IDie) movingCollision);
            DetectStaticBlocks(collideObjects, movingCollision);
            DetectEnemy(collideObjects, movingCollision);
            if(movingCollision is Hero)
                DetectCollectable(collideObjects,(ICanCollect) movingCollision);
            if (movingCollision is Enemy)
                DetectInvisibleBlock(collideObjects,(Enemy) movingCollision);
            if (movingCollision is IDeathBlock)
                DetectInvisibleBlockForProjectiles(collideObjects,movingCollision);
        }

        /// <summary>
        /// Detecteert onzichtbare blokken voor de projectielen
        /// </summary>
        /// <param name="collideObjects">Lijst met elk object dat kan colliden</param>
        /// <param name="movingCollide">bewegend object dat kan colliden</param>
        private static void DetectInvisibleBlockForProjectiles(List<ICollide> collideObjects,IMovingCollide movingCollide)
        {
            foreach (IInvisible invisibleBlock in collideObjects.OfType<IInvisible>())
            {
                if (movingCollide.CollisionRectangle.Intersects(invisibleBlock.CollisionRectangle))
                {
                    movingCollide.TouchingGround = true;
                }
            }
        }

        /// <summary>
        /// Detecteert onzichtbare blokken voor de enemies
        /// </summary>
        /// <param name="collideObjects">Lijst met elk object dat kan colliden</param>
        /// <param name="enemy">Enemy object waarop we controleren of we botsen met onzichtbare blokken</param>
        private static void DetectInvisibleBlock(List<ICollide> collideObjects,Enemy enemy)
        {
            foreach (IInvisible currentInvisibleBlock in collideObjects.OfType<IInvisible>())
            {
                if (enemy.CollisionRectangle.Intersects(currentInvisibleBlock.CollisionRectangle))
                {
                    if (enemy.IsLookingLeft)
                        enemy.TouchingLeft = true;
                    else enemy.TouchingRight = true;
                }

            }
        }
        /// <summary>
        /// Kijkt of de hero iets dodelijk heeft aangeraakt
        /// </summary>
        /// <param name="collideObjects">Lijst met alle objecten waar we mee kunnen colliden</param>
        /// <param name="canDieObject">bewegend object dat kan colliden</param>
        private static void DetectHeroDeath(List<ICollide> collideObjects, IDie canDieObject)
        {
            foreach (IDeathBlock deathBlock in collideObjects.OfType<IDeathBlock>())
            {
                if ( canDieObject.CollisionRectangle.Intersects(deathBlock.CollisionRectangle))
                    canDieObject.IsHit = true;
            }
            foreach (Enemy enemy in collideObjects.OfType<Enemy>())
            {
                if (canDieObject.CollisionRectangle.Intersects(enemy.CollisionRectangle))
                {
                    if (enemy.CurrentAnimation != enemy.DeathAnimation)
                    {
                        canDieObject.IsHit = true;
                        enemy.Attack = true;
                    }
                }
            }
        }

        /// <summary>
        /// Kijkt of we een collectable hebben aangeraakt met een object dat een collectable kan collecteren
        /// </summary>
        /// <param name="collideObjects">Lijst met alle objecten waar we mee kunnen colliden</param>
        /// <param name="canCollectObject">object dat kan colliden en beweegt</param>
        private static void DetectCollectable(List<ICollide> collideObjects, ICanCollect canCollectObject)
        {
            foreach (ICollectable collectable in collideObjects.OfType<ICollectable>().ToList())
            {
                if (canCollectObject is ICanCollect && canCollectObject.CollisionRectangle.Intersects(collectable.CollisionRectangle))
                {
                    collectable.IsCollected = true;
                    canCollectObject.HasTouchedCollectable = true;
                    collideObjects.Remove(collectable);
                }
            }
        }

        /// <summary>
        /// Kijkt of een enemy iets heeft aangeraakt
        /// </summary>
        /// <param name="collideObjects">Lijst met alle objecten waar we mee kunnen colliden</param>
        /// <param name="movingCollide">object dat kan colliden en beweegt</param>
        private static void DetectEnemy(List<ICollide> collideObjects, IMovingCollide movingCollide)
        {
            foreach (Enemy currentEnemy in collideObjects.OfType<Enemy>().ToList())
            {
                if (movingCollide is Hero && movingCollide.CollisionRectangle.Intersects(currentEnemy.CollisionRectangle))
                {
                    currentEnemy.TouchedHero = true;
                }
                if (movingCollide is Projectile && movingCollide.CollisionRectangle.Intersects(currentEnemy.CollisionRectangle))
                {
                    movingCollide.TouchingLeft = true;
                    currentEnemy.IsHit = true;
                }
            }
        }

        /// <summary>
        /// Controleert of we een static block hebben aangeraakt
        /// </summary>
        /// <param name="collideObjects">Lijst met alle objecten waar we mee kunnen colliden</param>
        /// <param name="movingCollide">object dat kan colliden en beweegt</param>
        private void DetectStaticBlocks(List<ICollide> collideObjects, IMovingCollide movingCollide)
        {
            foreach (ICollide currentBlock in collideObjects.OfType<StaticBlock>())
            {
                if (currentBlock is ICollectable || currentBlock is IDeathBlock || movingCollide is IDeathBlock)
                    continue;
                if (movingCollide.Velocity.X > 0 && IsTouchingLeft(currentBlock, movingCollide))
                {
                    if (currentBlock is IMoveBlock)
                        movingCollide.CurrentCollisionBlock = (IMoveBlock)currentBlock;
                    else movingCollide.CurrentCollisionBlock = null;
                    movingCollide.TouchingRight = true;
                }
                if (movingCollide.Velocity.X < 0 && IsTouchingRight(currentBlock, movingCollide))
                {
                    if (currentBlock is IMoveBlock )
                        movingCollide.CurrentCollisionBlock = (IMoveBlock)currentBlock;
                    else movingCollide.CurrentCollisionBlock = null;
                    movingCollide.TouchingLeft = true;
                }
                if (movingCollide.Velocity.Y > 0 && IsTouchingTop(currentBlock, movingCollide))
                {
                    movingCollide.TouchingGround = true;
                }
                if (movingCollide.Velocity.Y < 0 && IsTouchingBottom(currentBlock, movingCollide))
                {
                    movingCollide.TouchingTop = true;
                }
            }
        }

        /// <summary>
        /// Reset alle booleans van het bewegend collision object
        /// </summary>
        /// <param name="movingCollide">collision object dat beweegt</param>
        private static void ResetState(IMovingCollide movingCollide)
        {
            movingCollide.TouchingGround = false;
            movingCollide.TouchingTop = false;
            movingCollide.TouchingLeft = false;
            movingCollide.TouchingRight = false;
        }
    }
}
