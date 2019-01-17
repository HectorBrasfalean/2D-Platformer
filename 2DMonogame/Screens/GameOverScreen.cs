using _2DMonogame.Button;
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
    /// Verantwoordelijk voor het game over scherm
    /// </summary>
    class GameOverScreen : IScreenState
    {
        ScreenManager screenManager;
        MouseState mouseState, prevMouseState;
        ContentManager content;
        ButtonScreen mainMenuButton, quitButton, restartButton;
        Texture2D gameOverImage, mainMenuText, quitText, restartText;

        public GameOverScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;

        }

        /// <summary>
        /// Tekent het game over scherm
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="currentLevel">Level object dat ons huidig level bevat</param>
        public void Draw(SpriteBatch spriteBatch, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            spriteBatch.Draw(gameOverImage, Vector2.Zero, new Rectangle(0, 0, gameOverImage.Width, gameOverImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            restartButton.PosSize = new Rectangle(850, 250, restartText.Width, restartText.Height);
            spriteBatch.Draw(restartText, new Rectangle(850, 250, restartText.Width, restartText.Height), Color.White);
            mainMenuButton.PosSize = new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height);
            spriteBatch.Draw(mainMenuText, new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height), Color.White);
            spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
        }

        /// <summary>
        /// Laden van de content voor het game over scherm
        /// </summary>
        /// <param name="content">ContentManager object dat we gebruiken om textures te laden</param>
        public void Load(ContentManager content)
        {
            this.content = content;
            gameOverImage = content.Load<Texture2D>("gameOverMenu");
            quitText = content.Load<Texture2D>("quitbutton");
            restartText = content.Load<Texture2D>("restartbutton");
            mainMenuText = content.Load<Texture2D>("mainMenuButton");

            restartButton = new ButtonScreen(new Rectangle(850, 350, restartText.Width, restartText.Height), true);
            restartButton.Load(content, "restartbutton");

            quitButton = new ButtonScreen(new Rectangle(850, 450, quitText.Width, quitText.Height), true);
            quitButton.Load(content, "quitbutton");

            mainMenuButton = new ButtonScreen(new Rectangle(860, 450, mainMenuText.Width, mainMenuText.Height), true);
            mainMenuButton.Load(content, "mainmenubutton");
        }

        /// <summary>
        /// Update het game over scherm
        /// </summary>
        /// <param name="gameTime">GameTime object dat ervoor zorgt dat we iets op een bepaalde tijd kunnen afspelen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="collisionObjects">Lijst met alle objecten die kunnen colliden</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="collider">Collider object die kijkt of er een collision gebeurt</param>
        /// <param name="currentLevel">Level object dat ons huidig level bevat</param>
        public void Update(GameTime gameTime, Camera2D camera, Hero hero, List<ICollide> collisionObjects, Background background, Collider collider,ref Level currentLevel)
        {
            mouseState = Mouse.GetState();
            screenManager.MakeMouseVisible(true);
            if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                screenManager.Quit();
            else if (mainMenuButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                screenManager.SetState(screenManager.GetMainMenuScreen());
            else if (restartButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
            {
                RestartLevel(new Vector2(150, 600),ref currentLevel,collisionObjects,hero);
                ResetHeroCollectedStars(hero);
                ResetHeroLives(hero);
                screenManager.SetState(screenManager.GetPlayScreen());
            }
            prevMouseState = mouseState;
        }
        /// <summary>
        /// Zet de hero zijn spawnlocatie op een bepaalde locatie
        /// </summary>
        /// <param name="spawnPos">de positie waar de hero zou moeten spawnen</param>
        /// <param name="hero">Hero object dat we besturen</param>
        private void SetHeroSpawnLocation(Vector2 spawnPos, Hero hero)
        {
            hero.RespawnLocation = spawnPos;
            hero.Position = hero.RespawnLocation;
        }
        /// <summary>
        /// Restart level
        /// </summary>
        /// <param name="spawnPosHero">Start positie van de hero</param>
        /// <param name="currentLevel">Huidige level</param>
        /// <param name="collisionObjects">Lijst met alle objecten die kunnen colliden</param>
        /// <param name="hero">Hero object dat we besturen</param>
        private void RestartLevel(Vector2 spawnPosHero,ref Level currentLevel, List<ICollide> collisionObjects, Hero hero)
        {
            collisionObjects.Clear();
            currentLevel = new Level1(content);
            currentLevel.CreateWorld(content, collisionObjects);
            SetHeroSpawnLocation(spawnPosHero, hero);
        }

        /// <summary>
        /// Reset het aantal van collected collectables van de hero
        /// </summary>
        /// <param name="hero">Hero object dat we besturen</param>
        private void ResetHeroCollectedStars(Hero hero)
        {
            hero.amountOfStarsCollected = 0;
        }

        /// <summary>
        /// Reset het aantal levens van de hero
        /// </summary>
        /// <param name="hero">Hero object dat we besturen</param>
        private void ResetHeroLives(Hero hero)
        {
            hero.AmountOfLives = 3;
        }
    }
}
