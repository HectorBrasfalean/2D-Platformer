using _2DMonogame.Button;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Screens
{
    /// <summary>
    /// Verantwoordelijk voor het speel scherm
    /// </summary>
    class PlayScreen : IScreenState
    {
        bool escapeReleased,loadNextLevel;
        Texture2D star, heart;
        SpriteFont scoreFont;
        ScreenManager screenManager;
        Song song;

        public PlayScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        /// <summary>
        /// Laden van de content voor het speel scherm
        /// </summary>
        /// <param name="content">ContentManager object dat we gebruiken om textures te laden</param>
        public void Load(ContentManager content)
        {
            star = content.Load<Texture2D>("star");
            heart = content.Load<Texture2D>("heart");
            scoreFont = content.Load<SpriteFont>("Points");
            song = content.Load<Song>("Worldmap Theme");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume= 0.4f;
            MediaPlayer.Pause();
        }

        /// <summary>
        /// Tekent het speel scherm
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="currentLevel">Level object dat ons huidig level bevat</param>
        public void Draw(SpriteBatch spriteBatch,Camera2D camera,Hero hero,Background background,ref Level currentLevel)
        {
            spriteBatch.End();
            spriteBatch.Begin(transformMatrix: camera.Transform);
            background.Draw(spriteBatch);

            currentLevel.DrawWorld(spriteBatch);
            hero.Draw(spriteBatch);

            spriteBatch.Draw(star, new Vector2(hero.Position.X - 830, -220), null, Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(scoreFont, hero.amountOfStarsCollected + "x", new Vector2(hero.Position.X - 770, -210), Color.Black);
            spriteBatch.Draw(heart, new Vector2(hero.Position.X - 830, -150), null, Color.AliceBlue, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(scoreFont, hero.AmountOfLives + "x", new Vector2(hero.Position.X - 770, -150), Color.Black);
        }

        /// <summary>
        /// Update het speel scherm
        /// </summary>
        /// <param name="gameTime">GameTime object dat ervoor zorgt dat we iets op een bepaalde tijd kunnen afspelen</param>
        /// <param name="camera">Camera2D object dat de hero volgt</param>
        /// <param name="hero">Hero object dat we besturen</param>
        /// <param name="collisionObjects">Lijst met alle objecten die kunnen colliden</param>
        /// <param name="background">Background object voor de game</param>
        /// <param name="collider">Collider object die kijkt of er een collision gebeurt</param>
        /// <param name="currentLevel">Level object dat ons huidig level bevat</param>
        public void Update(GameTime gameTime,Camera2D camera,Hero hero,List<ICollide> collisionObjects,Background background,Collider collider,ref Level currentLevel)
        {
            MediaPlayer.Resume();
            KeyboardState keyboardState = Keyboard.GetState();
            screenManager.MakeMouseVisible(false);
            foreach (ButtonNextLevel nextLevelButton in collisionObjects.OfType<ButtonNextLevel>())
            {
                if (hero.CollisionRectangle.Intersects(nextLevelButton.CollisionRectangle) && hero.Velocity.Y > 5)
                    loadNextLevel = true;
            }
            if (keyboardState.IsKeyDown(Keys.Escape) && escapeReleased)
            {
                escapeReleased = false;
                MediaPlayer.Pause();
                screenManager.SetState(screenManager.GetPauseScreen());
            }
            if (keyboardState.IsKeyUp(Keys.Escape))
                escapeReleased = true;
            camera.Follow(hero);
            background.Update(hero.Position.X);
            hero.Update(gameTime, collisionObjects, collider);
            currentLevel.Update(gameTime, collisionObjects, collider);
            if (hero.AmountOfLives < 0 && hero.currentAnimation.CurrentFrame == hero.deathAnimation.frames[hero.deathAnimation.frames.Count - 1])
                screenManager.SetState(screenManager.GetGameOverScreen());
            if (loadNextLevel)
            {
                MediaPlayer.Pause();
                loadNextLevel = false;
                if (currentLevel is Level1)
                    screenManager.SetState(screenManager.GetNextLevel1Screen());
                else
                    screenManager.SetState(screenManager.GetNextLevel2Screen());
            }

            
        }
    }
}
