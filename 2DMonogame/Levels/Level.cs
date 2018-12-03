using _2DMonogame.Blocks;
using _2DMonogame.Blocks.Collectable;
using _2DMonogame.Characters;
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
        protected GameObject[,] GameObjectsArray;
                
        public Level(ContentManager content)
        {
            CreateArray();
            GameObjectsArray = new GameObject[TileArray.GetLength(0), TileArray.GetLength(1)];
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
                    GameObjectsArray[x,y] = levelFactory.GetGameObjectsLevel((int)TileArray[x, y], content, x, y,collisionObjects);
                }
            }
        }
        public void Update(GameTime gameTime,List<ICollide> collisionObjects,Collider collider)
        {
            foreach (IMove currentBlock in collisionObjects.OfType<IMove>())
            {
                currentBlock.Update(collisionObjects, collider);
            }
            foreach (Enemy enemy in collisionObjects.OfType<Enemy>().ToList())
            {
                enemy.Update(gameTime, collider, collisionObjects);
                if (enemy.currentAnimation == enemy.DeathAnimation && enemy.currentAnimation.CurrentFrame == enemy.DeathAnimation.frames[enemy.DeathAnimation.frames.Count - 1])
                    collisionObjects.Remove(enemy);
            }
        }
        public void DrawWorld(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < TileArray.GetLength(0); x++)
            {
                for (int y = 0; y < TileArray.GetLength(1); y++)
                {
                    if (GameObjectsArray[x, y] != null)
                    {
                        GameObjectsArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
