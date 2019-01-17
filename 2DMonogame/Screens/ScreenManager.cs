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
    /// <summary>
    /// Verantwoordelijk voor het managen van de verschillende schermen
    /// </summary>
    class ScreenManager
    {
        public bool CloseGame,MouseVisible;
        IScreenState playScreen;
        IScreenState pauseScreen;
        IScreenState gameOverScreen;
        IScreenState nextLevel1Screen;
        IScreenState nextLevel2Screen;
        IScreenState mainMenuScreen;
        IScreenState controlsScreen;
        IScreenState currentScreen;
        public ScreenManager(ContentManager content)
        {
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

        /// <summary>
        /// Update het huidige scherm in de screen manager
        /// </summary>
        /// <param name="gameTime">GameTime object dat ervoor zorgt dat we iets op een bepaalde tijd kunnen afspelen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="collisionObjects">Lijst met alle objecten dat kunnen colliden</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="collider">Collider object die kijkt of er een collision gebeurt</param>
        /// <param name="currentLevel">Huidige level</param>
        public void Update(GameTime gameTime, Camera2D camera, Hero hero, List<ICollide> collisionObjects, Background background, Collider collider,ref Level currentLevel)
        {
            currentScreen.Update(gameTime,camera,hero,collisionObjects,background,collider,ref currentLevel);
        }
        /// <summary>
        /// Tekent het huidige scherm in de screen manager
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="currentLevel">Huidige level</param>
        public void Draw(SpriteBatch spriteBatch, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            currentScreen.Draw(spriteBatch,camera,hero,background,ref currentLevel);
        }
        /// <summary>
        /// Zal het huidige scherm veranderen naar de goToScreen
        /// </summary>
        /// <param name="goToScreen">Het volgende scherm dat geladen moet worden</param>
        public void SetState(IScreenState goToScreen)
        {
            currentScreen = goToScreen;
        }
        /// <summary>
        /// Ophalen van het speel scherm
        /// </summary>
        /// <returns>Speel scherm</returns>
        public IScreenState GetPlayScreen()
        {
            return playScreen;
        }
        /// <summary>
        /// Ophalen van het main menu scherm
        /// </summary>
        /// <returns>Main menu scherm</returns>
        public IScreenState GetMainMenuScreen()
        {
            return mainMenuScreen;
        }
        /// <summary>
        /// Ophalen van het pauze scherm
        /// </summary>
        /// <returns>pauze scherm</returns>
        public IScreenState GetPauseScreen()
        {
            return pauseScreen;
        }
        /// <summary>
        /// Ophalen van het game over scherm
        /// </summary>
        /// <returns>Game over scherm</returns>
        public IScreenState GetGameOverScreen()
        {
            return gameOverScreen;
        }
        /// <summary>
        /// Ophalen van het scherm wanneer we level 1 hebben afgewerkt
        /// </summary>
        /// <returns>Level 1 compleet scherm</returns>
        public IScreenState GetNextLevel1Screen()
        {
            return nextLevel1Screen;
        }
        /// <summary>
        /// Ophalen van het scherm wanneer we level 2 hebben afgewerkt
        /// </summary>
        /// <returns>Level 2 compleet scherm</returns>
        public IScreenState GetNextLevel2Screen()
        {
            return nextLevel2Screen;
        }
        /// <summary>
        /// Ophalen van het controls scherm
        /// </summary>
        /// <returns>Controls scherm</returns>
        public IScreenState GetControlsScreen()
        {
            return controlsScreen;
        }

        /// <summary>
        /// Sluit de game
        /// </summary>
        public void Quit()
        {
            CloseGame = true;
        }
        /// <summary>
        /// Maakt de muiscursor onzichtbaar of zichtbaar
        /// </summary>
        /// <param name="isMouseVisible">Boolean die bepaalt of de muis zichtbaar is of niet</param>
        public void MakeMouseVisible(bool isMouseVisible)
        {
            MouseVisible = isMouseVisible;
        }
    }
}
