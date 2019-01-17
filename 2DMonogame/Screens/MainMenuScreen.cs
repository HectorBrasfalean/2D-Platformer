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
    /// Verantwoordelijk voor het main menu scherm
    /// </summary>
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

        /// <summary>
        /// Tekent het main menu scherm
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="currentLevel">Level object dat ons huidig level bevat</param>
        public void Draw(SpriteBatch spriteBatch, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            spriteBatch.Draw(mainScreenImage, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(playGameText, new Rectangle(850, 250, playGameText.Width, playGameText.Height), Color.White);
            spriteBatch.Draw(controlsText, new Rectangle(850, 350, controlsText.Width, controlsText.Height), Color.White);
            spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
        }


        /// <summary>
        /// Laden van de content voor het main menu scherm
        /// </summary>
        /// <param name="content">ContentManager object dat we gebruiken om textures te laden</param>
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

        /// <summary>
        /// Update het main menu scherm
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
            if (playGameButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
            {
                Thread.Sleep(100);
                LoadLevel(new Level1(content), new Vector2(150, 600),ref currentLevel, collisionObjects, hero);
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
        /// <summary>
        /// Laad nieuw level
        /// </summary>
        /// <param name="nextLevel">Volgende level dat geladen moet worden</param>
        /// <param name="spawnPosHero">Start positie van de hero</param>
        /// <param name="currentLevel">Huidige level</param>
        /// <param name="collisionObjects">Lijst met alle objecten die kunnen colliden</param>
        /// <param name="hero">Hero object dat we besturen</param>
        private void LoadLevel(Level nextLevel, Vector2 spawnPosHero,ref Level currentLevel,List<ICollide> collisionObjects,Hero hero)
        {
            currentLevel = nextLevel;
            currentLevel.CreateWorld(content, collisionObjects);
            SetHeroSpawnLocation(spawnPosHero,hero);
        }
        /// <summary>
        /// Zet de hero zijn spawnlocatie op een bepaalde locatie
        /// </summary>
        /// <param name="spawnPos">De positie waar de hero zou moeten spawnen</param>
        /// <param name="hero">Hero object dat we besturen</param>
        private void SetHeroSpawnLocation(Vector2 spawnPos,Hero hero)
        {
            hero.RespawnLocation = spawnPos;
            hero.Position = hero.RespawnLocation;
        }
    }
}
