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
        CollisionObject collider;
        int ScreenWidth;
        int ScreenHeight;
        Hero hero;
        Level level;
        Camera2D camera;
        List<ICollide> collisionObjects;
        //List<Block> blocks;

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
            collider = new CollisionObject();
            collisionObjects = new List<ICollide>();
            collisionObjects.Clear();
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            hero = new Hero(Content, new Vector2(150, 300), new MovementArrowKeys());

            collisionObjects.Add(hero);

            level = new Level1(Content);
            camera = new Camera2D() { ScreenHeight = ScreenHeight, ScreenWidth = ScreenWidth ,Zoom = 0.75f};
            background = new Background(new Vector2(-150,-550));
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
            level.CreateWorld(Content, collisionObjects);
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
            collider.CollisionDetect(collisionObjects, hero);
            hero.Update(gameTime,collisionObjects);
            //level.CreateWorld(Content,collisionObjects);
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
            /*foreach (Block block in blocks)
            {
                block.Draw(spriteBatch);
            }*/
            level.DrawWorld(spriteBatch);
            hero.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
