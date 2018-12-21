using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _2DMonogame.Button;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DMonogame.Screens
{
    class PauseScreen : IScreenState
    {
        ScreenManager screenManager;
        MouseState mouseState, prevMouseState;
        KeyboardState keyboardState;
        ContentManager content;
        bool escapeReleased;
        ButtonScreen quitButton, restartButton, resumeButton;
        Texture2D pausedImage, quitText, resumeText, restartText;

        public PauseScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            spriteBatch.Draw(pausedImage, Vector2.Zero, new Rectangle(0, 0, pausedImage.Width, pausedImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(resumeText, new Rectangle(850, 250, resumeText.Width, resumeText.Height), Color.White);
            restartButton.PosSize = new Rectangle(850, 350, restartText.Width, restartText.Height);
            spriteBatch.Draw(restartText, new Rectangle(850, 350, restartText.Width, restartText.Height), Color.White);
            spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
        }

        public void Load(ContentManager content)
        {
            this.content = content;
            pausedImage = content.Load<Texture2D>("pausedMenu");
            quitText = content.Load<Texture2D>("quitbutton");
            resumeText = content.Load<Texture2D>("resumebutton");
            restartText = content.Load<Texture2D>("restartbutton");

            quitButton = new ButtonScreen(new Rectangle(850, 450, quitText.Width, quitText.Height), true);
            quitButton.Load(content, "quitbutton");

            restartButton = new ButtonScreen(new Rectangle(850, 350, restartText.Width, restartText.Height), true);
            restartButton.Load(content, "restartbutton");

            resumeButton = new ButtonScreen(new Rectangle(850, 250, resumeText.Width, resumeText.Height), true);
            resumeButton.Load(content, "resumebutton");
        }

        public void Update(GameTime gameTime, Camera2D camera, Hero hero, List<ICollide> collisionObjects, Background background, Collider collider,ref Level currentLevel)
        {
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();
            screenManager.MakeMouseVisible(true);
            if (keyboardState.IsKeyDown(Keys.Escape) && escapeReleased)
            {
                screenManager.SetState(screenManager.GetPlayScreen());
                escapeReleased = false;
            }
            if (keyboardState.IsKeyUp(Keys.Escape))
                escapeReleased = true;
            if (resumeButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
            {
                screenManager.SetState(screenManager.GetPlayScreen());
                escapeReleased = false;
            }
            else if (restartButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
            {
                escapeReleased = false;
                RestartLevel(new Vector2(150, 600),ref currentLevel,collisionObjects,hero);
                ResetHeroCollectedStars(hero);
                ResetHeroLives(hero);
                screenManager.SetState(screenManager.GetPlayScreen());
            }
            else if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                screenManager.Quit();
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
        private void RestartLevel(Vector2 spawnPosHero,ref Level currentLevel, List<ICollide> collisionObjects, Hero hero)
        {
            collisionObjects.Clear();
            currentLevel = new Level1(content);
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
