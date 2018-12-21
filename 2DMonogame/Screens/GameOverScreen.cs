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

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            spriteBatch.Draw(gameOverImage, Vector2.Zero, new Rectangle(0, 0, gameOverImage.Width, gameOverImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            restartButton.PosSize = new Rectangle(850, 250, restartText.Width, restartText.Height);
            spriteBatch.Draw(restartText, new Rectangle(850, 250, restartText.Width, restartText.Height), Color.White);
            mainMenuButton.PosSize = new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height);
            spriteBatch.Draw(mainMenuText, new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height), Color.White);
            spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
        }

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
                RestartLevel(new Level1(content), new Vector2(150, 600),ref currentLevel,collisionObjects,hero);
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
        private void SetHeroSpawnLocation(Vector2 spawnPos, Hero hero)
        {
            hero.RespawnLocation = spawnPos;
            hero.Position = hero.RespawnLocation;
        }
        /// <summary>
        /// Laad nieuw level
        /// </summary>
        /// <param name="nextLevel">het volgende level dat geladen moet worden</param>
        /// <param name="spawnPosHero">de spawn locatie van de hero</param>
        private void RestartLevel(Level nextLevel, Vector2 spawnPosHero,ref Level currentLevel, List<ICollide> collisionObjects, Hero hero)
        {
            collisionObjects.Clear();
            currentLevel = nextLevel;
            currentLevel.CreateWorld(content, collisionObjects);
            SetHeroSpawnLocation(spawnPosHero, hero);
        }

        private void ResetHeroCollectedStars(Hero hero)
        {
            hero.amountOfStarsCollected = 0;
        }
        /// <summary>
        /// Reset het aantal levens van de hero
        /// </summary>
        private void ResetHeroLives(Hero hero)
        {
            hero.AmountOfLives = 3;
        }
    }
}
