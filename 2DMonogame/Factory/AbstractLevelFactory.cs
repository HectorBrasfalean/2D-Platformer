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
        public GameObject GetGameObjectsLevel(int id, ContentManager content, int x, int y,List<ICollide> collisionObjects)
        {
            GameObject gameObject = CreateBlock(id, content);

            if (gameObject is ICollide)
                collisionObjects.Add((ICollide)gameObject);
            if (gameObject != null)
                gameObject.Initialize(new Vector2(y * 100, x * 100));
            return gameObject;
        }
        protected abstract GameObject CreateBlock(int id, ContentManager content);
    }
}
