using _2DMonogame.Button;
using _2DMonogame.Collision;
using _2DMonogame.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2DMonogame.Screens
{
    class NextLevel1Screen : IScreenState
    {
        MouseState mouseState, prevMouseState;
        ScreenManager screenManager;
        ContentManager content;
        ButtonScreen nextLevelButton, mainMenuButton, quitButton;
        Texture2D quitText, mainMenuText, nextLevelTexture, level1CompleteScreen;
        SpriteFont shootText;

        public NextLevel1Screen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            spriteBatch.Draw(level1CompleteScreen, Vector2.Zero, new Rectangle(0, 0, level1CompleteScreen.Width, level1CompleteScreen.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(shootText, "Stars collected : " + hero.amountOfStarsCollected + " / 35", new Vector2(300, 350), Color.Black);
            spriteBatch.Draw(nextLevelTexture, new Rectangle(850, 250, nextLevelTexture.Width, nextLevelTexture.Height), Color.White);
            mainMenuButton.PosSize = new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height);
            spriteBatch.Draw(mainMenuText, new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height), Color.White);
            spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
        }

        public void Load(ContentManager content)
        {
            this.content = content;
            quitText = content.Load<Texture2D>("quitbutton");
            mainMenuText = content.Load<Texture2D>("mainMenuButton");
            nextLevelTexture = content.Load<Texture2D>("nextlevelbutton");
            shootText = content.Load<SpriteFont>("shootText");
            level1CompleteScreen = content.Load<Texture2D>("level1CompleteMenu");

            quitButton = new ButtonScreen(new Rectangle(850, 450, quitText.Width, quitText.Height), true);
            quitButton.Load(content, "quitbutton");

            mainMenuButton = new ButtonScreen(new Rectangle(860, 450, mainMenuText.Width, mainMenuText.Height), true);
            mainMenuButton.Load(content, "mainmenubutton");

            nextLevelButton = new ButtonScreen(new Rectangle(860, 250, nextLevelTexture.Width, nextLevelTexture.Height), true);
            nextLevelButton.Load(content, "nextlevelbutton");

        }

        public void Update(GameTime gameTime, Camera2D camera, Hero hero, List<ICollide> collisionObjects, Background background, Collider collider,ref Level currentLevel)
        {
            mouseState = Mouse.GetState();
            screenManager.MakeMouseVisible(true);
            if (nextLevelButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
            {
                screenManager.SetState(screenManager.GetPlayScreen());
                hero.Position = new Vector2();
                LoadLevel(new Level2(content), new Vector2(150, 100),ref currentLevel,collisionObjects,hero);
                ResetHeroCollectedStars(hero);
            }
            else if (mainMenuButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
            {
                screenManager.SetState(screenManager.GetMainMenuScreen());
                Thread.Sleep(100);
            }
            else if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                screenManager.Quit();
            prevMouseState = mouseState;
        }

        private void ResetHeroCollectedStars(Hero hero)
        {
            hero.amountOfStarsCollected = 0;
        }

        private void LoadLevel(Level nextLevel, Vector2 spawnPosHero, ref Level currentLevel, List<ICollide> collisionObjects, Hero hero)
        {
            collisionObjects.Clear();
            currentLevel = nextLevel;
            currentLevel.CreateWorld(content, collisionObjects);
            SetHeroSpawnLocation(spawnPosHero, hero);
        }

        private void SetHeroSpawnLocation(Vector2 spawnPosHero, Hero hero)
        {
            hero.RespawnLocation = spawnPosHero;
            hero.Position = hero.RespawnLocation;
        }
    }
}
