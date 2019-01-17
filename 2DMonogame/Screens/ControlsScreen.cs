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
using System.Threading;
using System.Threading.Tasks;

namespace _2DMonogame.Screens
{
    /// <summary>
    /// Verantwoordelijk voor het controls scherm
    /// </summary>
    class ControlsScreen : IScreenState
    {
        MouseState mouseState, prevMouseState;
        ScreenManager screenManager;
        Texture2D controlsImage, mainMenuText, leftArrow, rightArrow, upArrow, spaceTexture;
        SpriteFont movementText, shootText;
        ButtonScreen mainMenuButton;
        public ControlsScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        /// <summary>
        /// Tekent het controls scherm
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="currentLevel">Level object dat ons huidig level bevat</param>
        public void Draw(SpriteBatch spriteBatch, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            spriteBatch.Draw(controlsImage, Vector2.Zero, new Rectangle(0, 0, controlsImage.Width, controlsImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            mainMenuButton.PosSize = new Rectangle(860, 450, mainMenuText.Width, mainMenuText.Height);
            spriteBatch.Draw(mainMenuText, new Rectangle(860, 450, mainMenuText.Width, mainMenuText.Height), Color.White);
            spriteBatch.Draw(leftArrow, new Vector2(830, 250), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(rightArrow, new Vector2(1030, 250), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(upArrow, new Vector2(930, 250), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(movementText, "Movement : ", new Vector2(550, 270), Color.Black);
            spriteBatch.DrawString(shootText, "Shoot : (Charge)", new Vector2(430, 360), Color.Black);
            spriteBatch.Draw(spaceTexture, new Vector2(840, 340), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Laden van de content voor het controls scherm
        /// </summary>
        /// <param name="content">ContentManager object dat we gebruiken om textures te laden</param>
        public void Load(ContentManager content)
        {
            leftArrow = content.Load<Texture2D>("leftArrow");
            rightArrow = content.Load<Texture2D>("rightArrow");
            upArrow = content.Load<Texture2D>("upArrow");
            spaceTexture = content.Load<Texture2D>("space");
            controlsImage = content.Load<Texture2D>("controlsMenu");
            mainMenuText = content.Load<Texture2D>("mainMenuButton");

            movementText = content.Load<SpriteFont>("movementText");
            shootText = content.Load<SpriteFont>("shootText");

            mainMenuButton = new ButtonScreen(new Rectangle(860, 450, mainMenuText.Width, mainMenuText.Height), true);
            mainMenuButton.Load(content, "mainmenubutton");
        }

        /// <summary>
        /// Update het controls scherm
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
            if (mainMenuButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
            {
                Thread.Sleep(100);
                screenManager.SetState(screenManager.GetMainMenuScreen());
            }
            prevMouseState = mouseState;
        }
    }
}
