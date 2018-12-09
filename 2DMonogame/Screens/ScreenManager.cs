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
        public void SetState(IScreenState goToScreen)
        {
            currentScreen = goToScreen;
        }
        public IScreenState GetPlayScreen()
        {
            return playScreen;
        }
        public IScreenState GetGameOverScreen()
        {
            return gameOverScreen;
        }
        public IScreenState GetControlsScreen()
        {
            return controlsScreen;
        }
        public IScreenState GetPauseScreen()
        {
            return pauseScreen;
        }
        public IScreenState GetMainMenuScreen()
        {
            return mainMenuScreen;
        }
        public void Load(ContentManager content, List<ICollide> collisionObjects,Level currentLevel, Background background)
        {
            currentScreen.Load(content,collisionObjects,currentLevel,background);
        }
        public void Draw(SpriteBatch spriteBatch, Hero hero, Camera2D camera, Level currentLevel, GraphicsDevice graphicsDevice, Background background, SpriteFont scoreFont)
        {
            currentScreen.Draw(spriteBatch,hero,camera,currentLevel,graphicsDevice,background,scoreFont);
        }
        public void Update(GameTime gameTime, MouseState mouseState, MouseState prevMouseState, List<ICollide> collisionObjects, Hero hero, Camera2D camera, Collider collider, Level currentLevel,Background background)
        {
            currentScreen.Update(gameTime, mouseState, prevMouseState,collisionObjects,hero,camera,collider,currentLevel,background);
        }
        public void QuitGame()
        {
            game.Exit();
        }
    }
}
