using _2DMonogame.Characters;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _2DMonogame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Background background;
        Collider collider;
        int ScreenWidth,ScreenHeight;
        Hero hero;
        Level currentLevel;
        Camera2D camera;
        List<ICollide> collisionObjects;
        SpriteFont scoreFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 780;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
        }
      
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            collider = new Collider();
            collisionObjects = new List<ICollide>();
            collisionObjects.Clear();
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            hero = new Hero(Content, new Vector2(150, 600), new MovementArrowKeys());

            collisionObjects.Add(hero);

            currentLevel = new Level1(Content);
            camera = new Camera2D() { ScreenHeight = ScreenHeight, ScreenWidth = ScreenWidth ,Zoom = 0.75f};
            background = new Background(new Vector2(-150,-250));
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background.backgroundTexture = Content.Load<Texture2D>("AangepasteBackground");
            scoreFont = Content.Load<SpriteFont>("Points");
            currentLevel.CreateWorld(Content, collisionObjects);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            camera.Follow(hero);
            background.Update(hero.Position.X);
            hero.Update(gameTime,collisionObjects,collider);
            currentLevel.Update(gameTime,collisionObjects, collider);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(transformMatrix:camera.Transform);

            background.Draw(spriteBatch,GraphicsDevice);

            currentLevel.DrawWorld(spriteBatch);
            hero.Draw(spriteBatch);

            spriteBatch.DrawString(scoreFont, "Stars collected : " + hero.amountOfStarsCollected, new Vector2(hero.Position.X - 830, -200), Color.Black);
            spriteBatch.DrawString(scoreFont, "Number of lives : " + hero.AmountOfLives, new Vector2(hero.Position.X - 830, -150), Color.Black);


            if(hero.amountOfStarsCollected == 30)
            {
                spriteBatch.DrawString(scoreFont, "You won! On to the next level.", new Vector2(hero.Position.X - 60, hero.Position.Y - 150), Color.Black);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
