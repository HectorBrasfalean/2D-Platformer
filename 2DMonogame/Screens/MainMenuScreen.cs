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
    class MainMenuScreen : IScreenState
    {
        Texture2D mainScreenImage, playGameText, controlsText, quitText;
        ButtonScreen playGameButton,quitButton,controlsButton;
        ScreenManager screenManager;
        ContentManager content;
        MouseState prevMouseState,mouseState;

        public MainMenuScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            spriteBatch.Draw(mainScreenImage, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(playGameText, new Rectangle(850, 250, playGameText.Width, playGameText.Height), Color.White);
            spriteBatch.Draw(controlsText, new Rectangle(850, 350, controlsText.Width, controlsText.Height), Color.White);
            spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
        }

        public void Load(ContentManager content)
        {
            this.content = content;
            mainScreenImage = content.Load<Texture2D>("mainMenu");
            controlsText = content.Load<Texture2D>("controlsbutton");
            playGameText = content.Load<Texture2D>("playbutton");
            quitText = content.Load<Texture2D>("quitbutton");

            playGameButton = new ButtonScreen(new Rectangle(850, 250, playGameText.Width, playGameText.Height), true);
            playGameButton.Load(content, "playbutton");

            controlsButton = new ButtonScreen(new Rectangle(850, 350, controlsText.Width, controlsText.Height), true);
            controlsButton.Load(content, "controlsbutton");

            quitButton = new ButtonScreen(new Rectangle(850, 450, quitText.Width, quitText.Height), true);
            quitButton.Load(content, "quitbutton");
        }

        public void Update(GameTime gameTime, Camera2D camera, Hero hero, List<ICollide> collisionObjects, Background background, Collider collider,ref Level currentLevel)
        {
            mouseState = Mouse.GetState();
            screenManager.MakeMouseVisible(true);
            if (playGameButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
            {
                LoadLevel(new Level1(content), new Vector2(11250, 100), currentLevel, collisionObjects, hero);
                ResetHeroCollectedStars(hero);
                ResetHeroLives(hero);
                screenManager.SetState(screenManager.GetPlayScreen());
            }
            else if (controlsButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                screenManager.SetState(screenManager.GetControlsScreen());
            else if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                screenManager.Quit();
            prevMouseState = mouseState;
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
        /// <summary>
        /// Laad nieuw level
        /// </summary>
        /// <param name="nextLevel">het volgende level dat geladen moet worden</param>
        /// <param name="spawnPosHero">de spawn locatie van de hero</param>
        private void LoadLevel(Level nextLevel, Vector2 spawnPosHero,Level currentLevel,List<ICollide> collisionObjects,Hero hero)
        {
            currentLevel = nextLevel;
            currentLevel.CreateWorld(content, collisionObjects);
            SetHeroSpawnLocation(spawnPosHero,hero);
        }
        /// <summary>
        /// Zet de hero zijn spawnlocatie op een bepaalde locatie
        /// </summary>
        /// <param name="spawnPos">de positie waar de hero zou moeten spawnen</param>
        private void SetHeroSpawnLocation(Vector2 spawnPos,Hero hero)
        {
            hero.RespawnLocation = spawnPos;
            hero.Position = hero.RespawnLocation;
        }
    }
}
