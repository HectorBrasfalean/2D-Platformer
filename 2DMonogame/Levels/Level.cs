using _2DMonogame.Blocks;
using _2DMonogame.Blocks.Collectable;
using _2DMonogame.Blocks.DeathBlocks;
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
    /// <summary>
    /// Verantwoordelijk voor het level
    /// </summary>
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
        /// <summary>
        /// Het aanmaken van een level
        /// </summary>
        /// <param name="content">ContentManager object dat we gebruiken om textures te laden</param>
        /// <param name="collisionObjects">Lijst met alle objecten dat kunnen colliden</param>
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

        /// <summary>
        /// Updaten van alle bewegende objecten in het level
        /// </summary>
        /// <param name="gameTime">GameTime object dat we gebruiken om iets op een bepaalde tijd af te spelen</param>
        /// <param name="collisionObjects">Lijst met alle objecten die kunnen colliden</param>
        /// <param name="collider">Collider object dat controlleert of er collision gebeurt</param>
        public void Update(GameTime gameTime,List<ICollide> collisionObjects,Collider collider)
        {
            foreach (IMoveBlock currentBlock in collisionObjects.OfType<IMoveBlock>())
            {
                currentBlock.Update(collisionObjects, collider);
            }
            foreach (Enemy enemy in collisionObjects.OfType<Enemy>().ToList())
            {
                enemy.Update(gameTime, collider, collisionObjects);
                if (enemy.CurrentAnimation == enemy.DeathAnimation && enemy.CurrentAnimation.CurrentFrame == enemy.DeathAnimation.frames[enemy.DeathAnimation.frames.Count - 1])
                    collisionObjects.Remove(enemy);
            }
            foreach (BouncingAcidBall ball in collisionObjects.OfType<BouncingAcidBall>())
            {
                ball.Update(gameTime, collider, collisionObjects);
            }
        }

        /// <summary>
        /// Tekent het volledige level
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
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
