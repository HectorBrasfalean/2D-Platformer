using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.Orc
{
    /// <summary>
    /// Verantwoordelijk voor de run animatie van de orc
    /// </summary>
    class OrcRunAnimation : Animation
    {
        public OrcRunAnimation()
        {
            PlaySpeed = 200;
        }

        /// <summary>
        /// Zet alle frames bijeen die we nodig hebben voor de run animatie van de orc
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 2344, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 2344, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 2344, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 2344, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 2344, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 2637, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 2637, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 2637, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 2637, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 2637, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 2930, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 2930, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 2930, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 2930, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 2930, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 3223, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 3223, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 3223, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 3223, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 3223, 347, 293) });
        }
    }
}
