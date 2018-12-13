using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Screens
{
    class ScreenManager
    {
        IScreenState currentScreen;
        IScreenState playScreen;
        IScreenState controlsScreen;
        IScreenState gameOverScreen;
        IScreenState pauseScreen;
        IScreenState mainMenuScreen;
        Game1 game;
        public ScreenManager(Game1 game)
        {
            this.game = game;
            playScreen = new PlayScreen(this);
            controlsScreen = new ControlsScreen(this);
            gameOverScreen = new GameOverScreen(this);
            pauseScreen = new PauseScreen(this);
            mainMenuScreen = new MainMenuScreen(this);
            currentScreen = mainMenuScreen;

        }

        /// <summary>
        /// Zet het momentele scherm naar een ander scherm
        /// </summary>
        /// <param name="goToScreen">het scherm waarnaar het momentele scherm naar toe moet springen</param>
        public void SetState(IScreenState goToScreen)
        {
            currentScreen = goToScreen;
        }
        /// <summary>
        /// Haalt het playScreen scherm op
        /// </summary>
        /// <returns>play scherm</returns>
        public IScreenState GetPlayScreen()
        {
            return playScreen;
        }
        /// <summary>
        /// Haalt het gameOver scherm op
        /// </summary>
        /// <returns>game over scherm</returns>
        public IScreenState GetGameOverScreen()
        {
            return gameOverScreen;
        }
        /// <summary>
        /// Haalt het controls scherm op
        /// </summary>
        /// <returns>controls scherm</returns>
        public IScreenState GetControlsScreen()
        {
            return controlsScreen;
        }
        /// <summary>
        /// Haalt het pauze scherm op
        /// </summary>
        /// <returns>pauze scherm</returns>
        public IScreenState GetPauseScreen()
        {
            return pauseScreen;
        }
        /// <summary>
        /// Haalt het hoofdscherm op
        /// </summary>
        /// <returns>hoofdscherm</returns>
        public IScreenState GetMainMenuScreen()
        {
            return mainMenuScreen;
        }
        /// <summary>
        /// Laad alle textures/fonts voor het momentele scherm
        /// </summary>
        /// <param name="content"></param>
        /// <param name="collisionObjects"></param>
        /// <param name="currentLevel"></param>
        /// <param name="background"></param>
        public void Load(ContentManager content, List<ICollide> collisionObjects,Level currentLevel, Background background)
        {
            currentScreen.Load(content,collisionObjects,currentLevel,background);
        }
        /// <summary>
        /// Tekent alle objecten voor het momentele scherm
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="hero"></param>
        /// <param name="camera"></param>
        /// <param name="currentLevel"></param>
        /// <param name="graphicsDevice"></param>
        /// <param name="background"></param>
        /// <param name="scoreFont"></param>
        public void Draw(SpriteBatch spriteBatch, Hero hero, Camera2D camera, Level currentLevel, GraphicsDevice graphicsDevice, Background background, SpriteFont scoreFont)
        {
            currentScreen.Draw(spriteBatch,hero,camera,currentLevel,graphicsDevice,background,scoreFont);
        }
        /// <summary>
        /// Update alle objecten voor het momentele scherm
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
            currentScreen.Update(gameTime, mouseState, prevMouseState,collisionObjects,hero,camera,collider,currentLevel,background);
        }
        /// <summary>
        /// Sluit het programma
        /// </summary>
        public void QuitGame()
        {
            game.Exit();
        }
    }
}
