using _2DMonogame.Blocks;
using _2DMonogame.Blocks.Collectable;
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
            DetectBlock(collideObjects, _object);
            foreach (Enemy currentEnemy in collideObjects.OfType<Enemy>().ToList<Enemy>())
            {
                if(_object is Hero && _object.CollisionRectangle.Intersects(currentEnemy.CollisionRectangle))
                {
                    currentEnemy.TouchedHero = true;
                }
                if (_object is Projectile && _object.CollisionRectangle.Intersects(currentEnemy.CollisionRectangle))
                {
                    _object.TouchingLeft = true;
                    currentEnemy.IsHit = true;
                    collideObjects.Remove(currentEnemy);
                }
            }
            foreach (ICollectable collectable in collideObjects.OfType<ICollectable>().ToList<ICollectable>())
            {
                if (_object is Hero && _object.CollisionRectangle.Intersects(collectable.CollisionRectangle))
                {
                    collectable.IsCollected = true;
                    _object.HasTouchedCollectable = true;
                    collideObjects.Remove(collectable);
                }

            }
        }
        private void DetectBlock(List<ICollide> collideObjects, IMovingCollide _object)
        {
            foreach (ICollide currentBlock in collideObjects.OfType<StaticBlock>())
            {
                if (currentBlock is ICollectable)
                    continue;
                if (_object.Velocity.X > 0 && IsTouchingLeft(currentBlock, _object))
                {
                   
                    if(currentBlock is IMove)
                        _object.currentCollisionBlock = (IMove)currentBlock;
                    _object.TouchingRight = true;
                }

                if (_object.Velocity.X < 0 && IsTouchingRight(currentBlock, _object))
                {
                    
                    if (currentBlock is IMove)
                        _object.currentCollisionBlock = (IMove)currentBlock;
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
