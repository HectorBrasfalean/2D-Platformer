using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Collision
{
    public interface IMovingCollide : ICollide
    {
        Vector2 Position { get; set; }
        float MovingSpeed { get; }
        Vector2 Velocity { get; set; }
        bool TouchingLeft { get; set; }
        bool TouchingRight { get; set; }
        bool TouchingGround { get; set; }
        bool TouchingTop { get; set; }
        void ChangeVelocity(float? x, float? y);
        void ChangePosition(float? x, float? y);
    }
}
