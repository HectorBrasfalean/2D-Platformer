using _2DMonogame.Collision;
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
    /// <summary>
    /// Verantwoordelijk voor het managen van de animatie
    /// </summary>
    abstract class Animation
    {
        public List<AnimationFrame> frames;
        double intervalTime = 0;
        int index = 0;
        public int PlaySpeed { get; set; }
        public AnimationFrame CurrentFrame { get; set; }
        public Animation()
        {
            frames = new List<AnimationFrame>();
            AddAnimation();
        }
        /// <summary>
        /// Reset de animatie
        /// </summary>
        public void Reset()
        {
            CurrentFrame = frames[0];
        }

        /// <summary>
        /// Voegt een frame toe aan de frames array
        /// </summary>
        /// <param name="aFrame"></param>
        public void AddFrame(AnimationFrame aFrame)
        {
            frames.Add(aFrame);
            Reset();
        }
        /// <summary>
        /// Zal de animatie afspelen afhankelijk van de snelheid die is ingesteld
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {

            intervalTime += PlaySpeed * gameTime.ElapsedGameTime.Milliseconds / 100;
            if (intervalTime >= 100)
            {
                index++;
                if (index > frames.Count - 1)
                    index = 0;

                CurrentFrame = frames[index];
                intervalTime = 0;
            }
        }
        
        protected abstract void AddAnimation();
    }
}
