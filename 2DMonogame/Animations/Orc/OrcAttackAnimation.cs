using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Animations.Orc
{
    /// <summary>
    /// Verantwoordelijk voor de aanval animatie van de orc
    /// </summary>
    class OrcAttackAnimation : Animation
    {
        public OrcAttackAnimation()
        {
            PlaySpeed = 200;
        }
        /// <summary>
        /// Voegt alle frames toe tot 1 aanval animatie voor de orc
        /// </summary>
        protected override void AddAnimation()
        {
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 0, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 0, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 0, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 0, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 0, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 293, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 293, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 293, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 293, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 293, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 586, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 586, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 586, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 586, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 586, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(0, 879, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(347, 879, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(694, 879, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1041, 879, 347, 293) });
            AddFrame(new AnimationFrame() { scale = 0.4f, RectangleSelector = new Rectangle(1388, 879, 347, 293) });
        }
    }
}
