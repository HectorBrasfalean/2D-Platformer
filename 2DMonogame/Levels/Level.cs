using _2DMonogame.Blocks;
using _2DMonogame.Blocks.Collectable;
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
    abstract class Level
    {
        protected ContentManager content;
        protected AbstractLevelFactory levelFactory;
        protected byte[,] TileArray;
        protected Block[,] BlockArray;
                
        public Level(ContentManager content)
        {
            CreateArray();
            BlockArray = new Block[TileArray.GetLength(0), TileArray.GetLength(1)];
            this.content = content;
            levelFactory = new LevelFactory();
        }
        protected abstract void CreateArray();
        public void CreateWorld(ContentManager content,List<ICollide> collisionObjects)
        {
            for (int x = 0; x < TileArray.GetLength(0); x++)
            {
                for (int y = 0; y < TileArray.GetLength(1); y++)
                {
                    BlockArray[x,y] = levelFactory.GetBlockLevel((int)TileArray[x, y], content, x, y,collisionObjects);
                }
            }
        }
        public void Update(List<ICollide> collisionObjects,Collider collider)
        {
            foreach (IMove currentBlock in collisionObjects.OfType<IMove>())
            {
                currentBlock.Update(collisionObjects, collider);
            }
            /*foreach (ICollectable collectable in collisionObjects.OfType<ICollectable>())
            {
                collectable.Update(collisionObjects, collider);
            }*/
        }
        public void DrawWorld(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < TileArray.GetLength(0); x++)
            {
                for (int y = 0; y < TileArray.GetLength(1); y++)
                {
                    if (BlockArray[x, y] != null)
                    {
                        BlockArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
