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
    class CollisionObject
    {
        private bool IsTouchingLeft(ICollide sprite,IMovingCollide _object)
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
            foreach (ICollide currentObject in collideObjects.OfType<StaticBlock>())
            {
                ResetState(_object);
                if (_object.Velocity.X > 0 && IsTouchingLeft(currentObject, _object))
                {
                    _object.ChangeVelocity(0,null);
                    _object.ChangePosition(_object.Position.X - _object.MovingSpeed, null);
                    _object.TouchingRight = true;
                }

                if (_object.Velocity.X < 0 && IsTouchingRight(currentObject, _object))
                {
                    _object.ChangePosition(_object.Position.X + _object.MovingSpeed, null);
                    _object.ChangeVelocity(0, null);
                    _object.TouchingLeft = true;
                }
                if (_object.Velocity.Y > 0 && IsTouchingTop(currentObject, _object))
                {
                    _object.ChangeVelocity(null,0);
                    _object.TouchingGround = true;
                }
                if (_object.Velocity.Y < 0 && IsTouchingBottom(currentObject, _object))
                {
                    _object.ChangeVelocity(null, 0.1f);
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
