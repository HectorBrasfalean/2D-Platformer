using _2DMonogame.Blocks;
using _2DMonogame.Blocks.Collectable;
using _2DMonogame.Blocks.DeathBlocks;
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
    class Collider
    {
        private bool IsTouchingLeft(ICollide sprite, IMovingCollide _object)
        {
            return _object.CollisionRectangle.Right + _object.Velocity.X > sprite.CollisionRectangle.Left &&
              _object.CollisionRectangle.Left < sprite.CollisionRectangle.Left &&
              _object.CollisionRectangle.Bottom > sprite.CollisionRectangle.Top &&
              _object.CollisionRectangle.Top < sprite.CollisionRectangle.Bottom;
        }

        private bool IsTouchingRight(ICollide sprite, IMovingCollide _object)
        {
            return _object.CollisionRectangle.Left + _object.Velocity.X < sprite.CollisionRectangle.Right &&
              _object.CollisionRectangle.Right > sprite.CollisionRectangle.Right &&
              _object.CollisionRectangle.Bottom > sprite.CollisionRectangle.Top &&
              _object.CollisionRectangle.Top < sprite.CollisionRectangle.Bottom;
        }

        private bool IsTouchingTop(ICollide sprite, IMovingCollide _object)
        {
            return _object.CollisionRectangle.Bottom + _object.Velocity.Y > sprite.CollisionRectangle.Top &&
              _object.CollisionRectangle.Top < sprite.CollisionRectangle.Top &&
              _object.CollisionRectangle.Right > sprite.CollisionRectangle.Left &&
              _object.CollisionRectangle.Left < sprite.CollisionRectangle.Right;
        }

        private bool IsTouchingBottom(ICollide sprite, IMovingCollide _object)
        {
            return _object.CollisionRectangle.Top + _object.Velocity.Y < sprite.CollisionRectangle.Bottom &&
              _object.CollisionRectangle.Bottom > sprite.CollisionRectangle.Bottom &&
              _object.CollisionRectangle.Right > sprite.CollisionRectangle.Left &&
              _object.CollisionRectangle.Left < sprite.CollisionRectangle.Right;
        }
        public void CollisionDetect(List<ICollide> collideObjects, IMovingCollide _object)
        {
            ResetState(_object);
            if(_object is Hero)
                DetectHeroDeath(collideObjects,(IDie) _object);
            DetectStaticBlocks(collideObjects, _object);
            DetectEnemy(collideObjects, _object);
            if(_object is Hero)
                DetectCollectable(collideObjects,(ICanCollect) _object);
        }

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
                    _object.IsHit = true;
            }
        }

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

        private void DetectStaticBlocks(List<ICollide> collideObjects, IMovingCollide _object)
        {
            foreach (ICollide currentBlock in collideObjects.OfType<StaticBlock>())
            {
                if (currentBlock is ICollectable || currentBlock is IDeathBlock)
                    continue;
                if (_object.Velocity.X > 0 && IsTouchingLeft(currentBlock, _object))
                {
                    if(currentBlock is IMoveBlock)
                        _object.currentCollisionBlock = (IMoveBlock)currentBlock;
                    _object.TouchingRight = true;
                }
                if (_object.Velocity.X < 0 && IsTouchingRight(currentBlock, _object))
                {
                    if (currentBlock is IMoveBlock )
                        _object.currentCollisionBlock = (IMoveBlock)currentBlock;
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

        private static void ResetState(IMovingCollide _object)
        {
            _object.TouchingGround = false;
            _object.TouchingTop = false;
            _object.TouchingLeft = false;
            _object.TouchingRight = false;
        }
    }
}
