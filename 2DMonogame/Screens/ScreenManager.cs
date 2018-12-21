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
        Game1 game;
        IScreenState playScreen;
        IScreenState pauseScreen;
        IScreenState gameOverScreen;
        IScreenState nextLevel1Screen;
        IScreenState nextLevel2Screen;
        IScreenState mainMenuScreen;
        IScreenState controlsScreen;
        IScreenState currentScreen;
        public ScreenManager(ContentManager content,Game1 game)
        {
            this.game = game;
            playScreen = new PlayScreen(this);
            playScreen.Load(content);
            pauseScreen = new PauseScreen(this);
            pauseScreen.Load(content);
            gameOverScreen = new GameOverScreen(this);
            gameOverScreen.Load(content);
            nextLevel1Screen = new NextLevel1Screen(this);
            nextLevel1Screen.Load(content);
            nextLevel2Screen = new NextLevel2Screen(this);
            nextLevel2Screen.Load(content);
            mainMenuScreen = new MainMenuScreen(this);
            mainMenuScreen.Load(content);
            controlsScreen = new ControlsScreen(this);
            controlsScreen.Load(content);
            currentScreen = mainMenuScreen;
        }

        public void Update(GameTime gameTime, Camera2D camera, Hero hero, List<ICollide> collisionObjects, Background background, Collider collider,ref Level currentLevel)
        {
            currentScreen.Update(gameTime,camera,hero,collisionObjects,background,collider,ref currentLevel);
        }
        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            currentScreen.Draw(spriteBatch,graphicsDevice,camera,hero,background,ref currentLevel);
        }
        public void SetState(IScreenState goToScreen)
        {
            currentScreen = goToScreen;
        }
        public IScreenState GetPlayScreen()
        {
            return playScreen;
        }
        public IScreenState GetMainMenuScreen()
        {
            return mainMenuScreen;
        }
        public IScreenState GetPauseScreen()
        {
            return pauseScreen;
        }
        public IScreenState GetGameOverScreen()
        {
            return gameOverScreen;
        }
        public IScreenState GetNextLevel1Screen()
        {
            return nextLevel1Screen;
        }
        public IScreenState GetNextLevel2Screen()
        {
            return nextLevel2Screen;
        }
        public IScreenState GetControlsScreen()
        {
            return controlsScreen;
        }
        public void Quit()
        {
            game.Exit();
        }
        public void MakeMouseVisible(bool isMouseVisible)
        {
            game.IsMouseVisible = isMouseVisible;
        }
    }
}
