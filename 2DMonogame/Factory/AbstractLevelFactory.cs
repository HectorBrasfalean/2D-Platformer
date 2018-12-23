using _2DMonogame.Blocks;
using _2DMonogame.Blocks.MovingBlocks;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor het halen van
    /// alle gameobjecten voor het level
    /// </summary>
    abstract class AbstractLevelFactory
    {
        /// <summary>
        /// Haalt een gameobject op
        /// </summary>
        /// <param name="id">Nummer van blok dat we moeten aanmaken</param>
        /// <param name="content">ContentManager die we gebruiken om textures te laden</param>
        /// <param name="x">positie op de x-as in de 2D array</param>
        /// <param name="y">positie op de y-as in de 2D array</param>
        /// <param name="collisionObjects">Lijt met alle objecten dat kunnen colliden</param>
        /// <returns>Het gameobject dat is aangemaakt</returns>
        public GameObject GetGameObjectsLevel(int id, ContentManager content, int y, int x,List<ICollide> collisionObjects)
        {
            GameObject gameObject = CreateBlock(id, content);

            if (gameObject is ICollide)
                collisionObjects.Add((ICollide)gameObject);
            if (gameObject != null)
                gameObject.Initialize(new Vector2(x * 100, y * 100));
            return gameObject;
        }
        protected abstract GameObject CreateBlock(int id, ContentManager content);
    }
}
