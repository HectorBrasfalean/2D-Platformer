using _2DMonogame.Button;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _2DMonogame.Screens
{
    class ControlsScreen : ScreenState
    {
        ButtonScreen mainMenuButton;
        Texture2D mainScreenImage, mainMenuText, leftArrow, rightArrow, upArrow, spaceTexture;
        SpriteFont movementText, shootText;
        ScreenManager screenManager;
        public ControlsScreen(ScreenManager screenManager)
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
        /// Update alle objecten voor het controls scherm
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
