using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.Orc
{
    /// <summary>
    /// Verantwoordelijk voor de dood animatie van de orc
    /// </summary>
    class OrcDieAnimation : Animation
    {
        public OrcDieAnimation()
        {
            PlaySpeed = 200;
        }
        /// <summary>
        /// Zet alle frames bijeen zodat we de dood animatie bekomen voor de orc
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 1172, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 1172, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 1172, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 1172, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 1172, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 1465, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 1465, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 1465, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 1465, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 1465, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 1758, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 1758, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 1758, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 1758, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 1758, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 2051, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 2051, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 2051, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 2051, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 2051, 347, 293) });
        }
    }
}
