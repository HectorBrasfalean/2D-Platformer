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
        /// Controleert of we de linkerkant van de sprite aanraken
        /// </summary>
        /// <param name="sprite">collision object</param>
        /// <param name="movingCollision">bewegend collision object</param>
        /// <returns></returns>
        private bool IsTouchingLeft(ICollide sprite, IMovingCollide movingCollision)
        {
            return movingCollision.CollisionRectangle.Right + movingCollision.Velocity.X > sprite.CollisionRectangle.Left &&
              movingCollision.CollisionRectangle.Left < sprite.CollisionRectangle.Left &&
              movingCollision.CollisionRectangle.Bottom > sprite.CollisionRectangle.Top &&
              movingCollision.CollisionRectangle.Top < sprite.CollisionRectangle.Bottom;
        }

        /// <summary>
        /// Controleert of we de rechterkant van de sprite aanraken
        /// </summary>
        /// <param name="sprite">collision object</param>
        /// <param name="movingCollision">bewegend collision object</param>
        /// <returns></returns>
        private bool IsTouchingRight(ICollide sprite, IMovingCollide movingCollision)
        {
            return movingCollision.CollisionRectangle.Left + movingCollision.Velocity.X < sprite.CollisionRectangle.Right &&
              movingCollision.CollisionRectangle.Right > sprite.CollisionRectangle.Right &&
              movingCollision.CollisionRectangle.Bottom > sprite.CollisionRectangle.Top &&
              movingCollision.CollisionRectangle.Top < sprite.CollisionRectangle.Bottom;
        }
        /// <summary>
        /// Controleert of we de bovenkant raken van de sprite
        /// </summary>
        /// <param name="sprite">collision object</param>
        /// <param name="movingCollision">bewegend collision object</param>
        /// <returns></returns>
        private bool IsTouchingTop(ICollide sprite, IMovingCollide movingCollision)
        {
            return movingCollision.CollisionRectangle.Bottom + movingCollision.Velocity.Y > sprite.CollisionRectangle.Top &&
              movingCollision.CollisionRectangle.Top < sprite.CollisionRectangle.Top &&
              movingCollision.CollisionRectangle.Right > sprite.CollisionRectangle.Left &&
              movingCollision.CollisionRectangle.Left < sprite.CollisionRectangle.Right;
        }
        /// <summary>
        /// Controleert of we de onderkant raken van de sprite
        /// </summary>
        /// <param name="sprite">collision object</param>
        /// <param name="movingCollision">bewegend collision object</param>
        /// <returns></returns>
        private bool IsTouchingBottom(ICollide sprite, IMovingCollide movingCollision)
        {
            return movingCollision.CollisionRectangle.Top + movingCollision.Velocity.Y < sprite.CollisionRectangle.Bottom &&
              movingCollision.CollisionRectangle.Bottom > sprite.CollisionRectangle.Bottom &&
              movingCollision.CollisionRectangle.Right > sprite.CollisionRectangle.Left &&
              movingCollision.CollisionRectangle.Left < sprite.CollisionRectangle.Right;
        }
        /// <summary>
        /// Kijkt of er een collision gebeurt
        /// </summary>
        /// <param name="collideObjects">Lijst met elk object dat kan colliden</param>
        /// <param name="movingCollision">object dat kan colliden en beweegt</param>
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
        /// <param name="_object">object dat kan colliden en beweegt</param>
        private static void DetectInvisibleBlockForProjectiles(List<ICollide> collideObjects,IMovingCollide _object)
        {
            foreach (IInvisible invisibleBlock in collideObjects.OfType<IInvisible>())
            {
                if (_object.CollisionRectangle.Intersects(invisibleBlock.CollisionRectangle))
                {
                    _object.TouchingGround = true;
                }
            }
        }

        /// <summary>
        /// Detecteert onzichtbare blokken
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
        /// <param name="_object">object dat kan colliden en beweegt</param>
        private static void DetectHeroDeath(List<ICollide> collideObjects, IDie _object)
        {
            foreach (IDeathBlock deathBlock in collideObjects.OfType<IDeathBlock>())
            {
                if ( _object.CollisionRectangle.Intersects(deathBlock.CollisionRectangle))
                    _object.IsHit = true;
            }
            foreach (Enemy enemy in collideObjects.OfType<Enemy>())
            {
                if (_object.CollisionRectangle.Intersects(enemy.CollisionRectangle))
                {
                    if (enemy.CurrentAnimation != enemy.DeathAnimation)
                    {
                        _object.IsHit = true;
                        enemy.Attack = true;
                    }
                }
            }
        }

        /// <summary>
        /// Kijkt of we een collectable hebben aangeraakt
        /// </summary>
        /// <param name="collideObjects">Lijst met alle objecten waar we mee kunnen colliden</param>
        /// <param name="_object">object dat kan colliden en beweegt</param>
        private static void DetectCollectable(List<ICollide> collideObjects, ICanCollect _object)
        {
            foreach (ICollectable collectable in collideObjects.OfType<ICollectable>().ToList())
            {
                if (_object is ICanCollect && _object.CollisionRectangle.Intersects(collectable.CollisionRectangle))
                {
                    collectable.IsCollected = true;
                    _object.HasTouchedCollectable = true;
                    collideObjects.Remove(collectable);
                }
            }
        }

        /// <summary>
        /// Kijkt of een enemy iets heeft aangeraakt
        /// </summary>
        /// <param name="collideObjects">Lijst met alle objecten waar we mee kunnen colliden</param>
        /// <param name="_object">object dat kan colliden en beweegt</param>
        private static void DetectEnemy(List<ICollide> collideObjects, IMovingCollide _object)
        {
            foreach (Enemy currentEnemy in collideObjects.OfType<Enemy>().ToList())
            {
                if (_object is Hero && _object.CollisionRectangle.Intersects(currentEnemy.CollisionRectangle))
                {
                    currentEnemy.TouchedHero = true;
                }
                if (_object is Projectile && _object.CollisionRectangle.Intersects(currentEnemy.CollisionRectangle))
                {
                    _object.TouchingLeft = true;
                    currentEnemy.IsHit = true;
                }
            }
        }

        /// <summary>
        /// Controleert of we een static block hebben aangeraakt
        /// </summary>
        /// <param name="collideObjects">Lijst met alle objecten waar we mee kunnen colliden</param>
        /// <param name="_object">object dat kan colliden en beweegt</param>
        private void DetectStaticBlocks(List<ICollide> collideObjects, IMovingCollide _object)
        {
            foreach (ICollide currentBlock in collideObjects.OfType<StaticBlock>())
            {
                if (currentBlock is ICollectable || currentBlock is IDeathBlock || _object is IDeathBlock)
                    continue;
                if (_object.Velocity.X > 0 && IsTouchingLeft(currentBlock, _object))
                {
                    if (currentBlock is IMoveBlock)
                        _object.currentCollisionBlock = (IMoveBlock)currentBlock;
                    else _object.currentCollisionBlock = null;
                    _object.TouchingRight = true;
                }
                if (_object.Velocity.X < 0 && IsTouchingRight(currentBlock, _object))
                {
                    if (currentBlock is IMoveBlock )
                        _object.currentCollisionBlock = (IMoveBlock)currentBlock;
                    else _object.currentCollisionBlock = null;
                    _object.TouchingLeft = true;
                }
                if (_object.Velocity.Y > 0 && IsTouchingTop(currentBlock, _object))
                {
                    _object.TouchingGround = true;
                }
                if (_object.Velocity.Y < 0 && IsTouchingBottom(currentBlock, _object))
                {
                    _object.TouchingTop = true;
                }
            }
        }

        /// <summary>
        /// Reset alle booleans
        /// </summary>
        /// <param name="_object">collision object dat beweeegt</param>
        private static void ResetState(IMovingCollide _object)
        {
            _object.TouchingGround = false;
            _object.TouchingTop = false;
            _object.TouchingLeft = false;
            _object.TouchingRight = false;
        }
    }
}
