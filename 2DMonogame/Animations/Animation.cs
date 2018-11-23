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
    abstract class Animation
    {
        public List<AnimationFrame> frames;
        double intervalTime = 0;
        int index = 0;
        public int Speed { get; set; }
        public AnimationFrame CurrentFrame { get; set; }
        public Animation()
        {
            frames = new List<AnimationFrame>();
            AddAnimation();
        }
        public void Reset()
        {
            CurrentFrame = frames[0];
        }
        public void AddFrame(AnimationFrame aFrame)
        {
            frames.Add(aFrame);
            Reset();
        }
        public void Update(GameTime gameTime,Hero hero = null)
        {
            if (hero != null) {
                CheckWhichAnimation(hero);
            }

            intervalTime += Speed * gameTime.ElapsedGameTime.Milliseconds / 100;
            if (intervalTime >= 100)
            {
                index++;
                if (index > frames.Count - 1)
                    index = 0;

                CurrentFrame = frames[index];
                intervalTime = 0;
            }
        }
        private void CheckWhichAnimation(Hero hero)
        {
            if (hero.movement.Jump)
            {
                if (hero.movement.Right)
                    hero.isLookingLeft = false;
                if (hero.movement.Left)
                    hero.isLookingLeft = true;
                hero.currentAnimation = hero.jumpAnimation;
            }
            else if (hero.movement.Right)
            {
                hero.isLookingLeft = false;
                if (hero.Velocity.Y == 0)
                    hero.currentAnimation = hero.runAnimation;
            }
            else if (hero.movement.Left)
            {
                hero.isLookingLeft = true;
                if (hero.Velocity.Y == 0)
                    hero.currentAnimation = hero.runAnimation;
            }
            else if (hero.movement.Attack && hero.Velocity.Y == 0)
            {
                hero.currentAnimation = hero.attackAnimation;
      
            }
            else
            {
                if (hero.Velocity.Y == 0)
                    hero.currentAnimation = hero.idleAnimation;
            }
        }


        protected abstract void AddAnimation();
    }
}
