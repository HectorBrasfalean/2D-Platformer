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
    /// <summary>
    /// Verantwoordelijk voor het scherm als we level 1 hebben afgewerkt
    /// </summary>
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


        /// <summary>
        /// Tekent het scherm als we level 1 hebben afgewerkt
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="currentLevel">Level object dat ons huidig level bevat</param>
        public void Draw(SpriteBatch spriteBatch, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            spriteBatch.Draw(level1CompleteScreen, Vector2.Zero, new Rectangle(0, 0, level1CompleteScreen.Width, level1CompleteScreen.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(shootText, "Stars collected : " + hero.amountOfStarsCollected + " / 35", new Vector2(300, 350), Color.Black);
            spriteBatch.Draw(nextLevelTexture, new Rectangle(850, 250, nextLevelTexture.Width, nextLevelTexture.Height), Color.White);
            mainMenuButton.PosSize = new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height);
            spriteBatch.Draw(mainMenuText, new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height), Color.White);
            spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
        }


        /// <summary>
        /// Laden van de content voor het scherm als we level 1 afgewerkt hebben
        /// </summary>
        /// <param name="content">ContentManager object dat we gebruiken om textures te laden</param>
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

        /// <summary>
        /// Update het scherm als we level 1 hebben afgewerkt
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

        /// <summary>
        /// Reset het aantal van collected collectables van de hero
        /// </summary>
        /// <param name="hero">Hero object dat we besturen</param>
        private void ResetHeroCollectedStars(Hero hero)
        {
            hero.amountOfStarsCollected = 0;
        }

        /// <summary>
        /// Laad een nieuw level
        /// </summary>
        /// <param name="nextLevel">Volgende level dat geladen moet worden</param>
        /// <param name="spawnPosHero">Start positie van hero</param>
        /// <param name="currentLevel">Huidige level</param>
        /// <param name="collisionObjects">Lijst met objecten dat kunnen colliden</param>
        /// <param name="hero">Hero object dat we besturen</param>
        private void LoadLevel(Level nextLevel, Vector2 spawnPosHero, ref Level currentLevel, List<ICollide> collisionObjects, Hero hero)
        {
            collisionObjects.Clear();
            currentLevel = nextLevel;
            currentLevel.CreateWorld(content, collisionObjects);
            SetHeroSpawnLocation(spawnPosHero, hero);
        }

        /// <summary>
        /// Zet de hero start positie
        /// </summary>
        /// <param name="spawnPosHero">Start positie van de hero</param>
        /// <param name="hero">Hero object dat we besturen</param>
        private void SetHeroSpawnLocation(Vector2 spawnPosHero, Hero hero)
        {
            hero.RespawnLocation = spawnPosHero;
            hero.Position = hero.RespawnLocation;
        }
    }
}
