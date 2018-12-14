using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Button;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DMonogame.Screens
{
    class GameOverScreen : ScreenState
    {
        ButtonScreen mainMenuButton, quitButton;
        ScreenManager screenManager;
        public GameOverScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        /// <summary>
        /// Tekent alle objecten voor het controls scherm
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="hero"></param>
        /// <param name="camera"></param>
        /// <param name="currentLevel"></param>
        /// <param name="graphicsDevice"></param>
        /// <param name="background"></param>
        /// <param name="scoreFont"></param>
        public void Draw(SpriteBatch spriteBatch, Hero hero, Camera2D camera, Level currentLevel, GraphicsDevice graphicsDevice,Background background, SpriteFont scoreFont)
        {
           
        }

        /// <summary>
        /// Laad alle textures voor het controls scherm
        /// </summary>
        /// <param name="content"></param>
        /// <param name="collisionObjects"></param>
        /// <param name="currentLevel"></param>
        /// <param name="background"></param>
        public void Load(ContentManager content, List<ICollide> collisionObjects, Level currentLevel,Background background)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="mouseState"></param>
        /// <param name="prevMouseState"></param>
        /// <param name="collisionObjects"></param>
        /// <param name="hero"></param>
        /// <param name="camera"></param>
        /// <param name="collider"></param>
        /// <param name="currentLevel"></param>
        /// <param name="background"></param>
        public void Update(GameTime gameTime, MouseState mouseState, MouseState prevMouseState, List<ICollide> collisionObjects, Hero hero, Camera2D camera, Collider collider, Level currentLevel,Background background)
        {

        }
    }
}
