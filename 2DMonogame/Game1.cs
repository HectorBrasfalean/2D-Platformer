using _2DMonogame.Button;
using _2DMonogame.Characters;
using _2DMonogame.Collision;
using _2DMonogame.Levels;
using _2DMonogame.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _2DMonogame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        bool escapeReleased = true,loadNextLevel;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Background background;
        Collider collider;
        int ScreenWidth,ScreenHeight;
        Hero hero;
        Level currentLevel;
        Camera2D camera;
        List<ICollide> collisionObjects;

        ScreenManager screenManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 780;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
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

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            hero = new Hero(Content, new Vector2(150, 600), new MovementArrowKeys());

            collisionObjects.Add(hero);

            currentLevel = new Level1(Content);

            camera = new Camera2D() { ScreenHeight = ScreenHeight, ScreenWidth = ScreenWidth ,Zoom = 0.75f};

            background = new Background(new Vector2(-150,-250));

            screenManager = new ScreenManager(Content,this);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            background.BackgroundTexture = Content.Load<Texture2D>("AangepasteBackground");
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            screenManager.Update(gameTime, camera, hero, collisionObjects, background, collider,ref currentLevel);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            screenManager.Draw(spriteBatch, camera, hero, background,ref currentLevel);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
