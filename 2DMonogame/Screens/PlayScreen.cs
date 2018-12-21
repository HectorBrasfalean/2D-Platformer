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
    class PlayScreen : IScreenState
    {
        bool escapeReleased,loadNextLevel;
        Texture2D star, heart;
        SpriteFont scoreFont;
        ScreenManager screenManager;

        public PlayScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }
        public void Load(ContentManager content)
        {
            star = content.Load<Texture2D>("star");
            heart = content.Load<Texture2D>("heart");
            scoreFont = content.Load<SpriteFont>("Points");

        }
        public void Draw(SpriteBatch spriteBatch,GraphicsDevice graphicsDevice,Camera2D camera,Hero hero,Background background,ref Level currentLevel)
        {
            spriteBatch.End();
            spriteBatch.Begin(transformMatrix: camera.Transform);
            background.Draw(spriteBatch, graphicsDevice);

            currentLevel.DrawWorld(spriteBatch);
            hero.Draw(spriteBatch);

            spriteBatch.Draw(star, new Vector2(hero.Position.X - 830, -220), null, Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(scoreFont, hero.amountOfStarsCollected + "x", new Vector2(hero.Position.X - 770, -210), Color.Black);
            spriteBatch.Draw(heart, new Vector2(hero.Position.X - 830, -150), null, Color.AliceBlue, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(scoreFont, hero.AmountOfLives + "x", new Vector2(hero.Position.X - 770, -150), Color.Black);
        }
        public void Update(GameTime gameTime,Camera2D camera,Hero hero,List<ICollide> collisionObjects,Background background,Collider collider,ref Level currentLevel)
        {
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
                loadNextLevel = false;
                if (currentLevel is Level1)
                    screenManager.SetState(screenManager.GetNextLevel1Screen());
                else
                    screenManager.SetState(screenManager.GetNextLevel2Screen());
            }

            
        }
    }
}
