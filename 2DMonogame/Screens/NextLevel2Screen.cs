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
    /// <summary>
    /// Verantwoordelijk voor het scherm als we level 2 hebben afgewerkt
    /// </summary>
    class NextLevel2Screen : IScreenState
    {
        ScreenManager screenManager;
        MouseState mouseState, prevMouseState;
        ButtonScreen quitButton;
        Texture2D level2CompleteScreen, quitText;
        SpriteFont shootText;

        public NextLevel2Screen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        /// <summary>
        /// Tekent het scherm als we level 2 hebben afgewerkt
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="currentLevel">Level object dat ons huidig level bevat</param>
        public void Draw(SpriteBatch spriteBatch, Camera2D camera, Hero hero, Background background,ref Level currentLevel)
        {
            spriteBatch.Draw(level2CompleteScreen, Vector2.Zero, new Rectangle(0, 0, level2CompleteScreen.Width, level2CompleteScreen.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(shootText, "Stars collected : " + hero.amountOfStarsCollected + " / 30", new Vector2(300, 350), Color.Black);
            spriteBatch.Draw(quitText, new Rectangle(850, 250, quitText.Width, quitText.Height), Color.White);
        }


        /// <summary>
        /// Laden van de content voor het scherm als we level 2 afgewerkt hebben
        /// </summary>
        /// <param name="content">ContentManager object dat we gebruiken om textures te laden</param>
        public void Load(ContentManager content)
        {
            level2CompleteScreen = content.Load<Texture2D>("level2CompleteMenu");
            shootText = content.Load<SpriteFont>("shootText");
            quitText = content.Load<Texture2D>("quitbutton");

            quitButton = new ButtonScreen(new Rectangle(850, 250, quitText.Width, quitText.Height), true);
            quitButton.Load(content, "quitbutton");

        }

        /// <summary>
        /// Update het scherm als we level 2 hebben afgewerkt
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
            prevMouseState = mouseState;
        }
    }
}
