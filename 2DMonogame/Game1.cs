using _2DMonogame.Button;
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
        int CurrentScreen;
        const byte MENU = 0, PLAYGAME = 1, GAMEOVER = 2, CONTROLS = 3, PAUZE = 4;
        MouseState mouseState;
        MouseState prevMouseState;
        ButtonScreen playGameButton, controlsButton,quitButton,resumeButton,mainmenuButton;
        Texture2D  controlsText, playGameText, quitText,mainScreenImage,resumeText,mainmenuText,pausedText;
        Texture2D leftArrow, rightArrow, upArrow, spaceTexture;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Background background;
        Collider collider;
        int ScreenWidth,ScreenHeight;
        Hero hero;
        Level currentLevel;
        Camera2D camera;
        List<ICollide> collisionObjects;
        SpriteFont movementText, scoreFont, shootText;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 780;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";

            CurrentScreen = MENU;
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

            playGameText = Content.Load<Texture2D>("playbutton");
            quitText = Content.Load<Texture2D>("quitbutton");
            controlsText = Content.Load<Texture2D>("controlsbutton");
            resumeText = Content.Load<Texture2D>("resumebutton");
            mainmenuText = Content.Load<Texture2D>("mainmenubutton");
            mainScreenImage = Content.Load<Texture2D>("mainMenu");
            pausedText = Content.Load<Texture2D>("pausedbutton");
            movementText = Content.Load<SpriteFont>("movementText");
            leftArrow = Content.Load<Texture2D>("leftArrow");
            rightArrow = Content.Load<Texture2D>("rightArrow");
            upArrow = Content.Load<Texture2D>("upArrow");
            spaceTexture = Content.Load<Texture2D>("space");
            shootText = Content.Load<SpriteFont>("shootText");

            mainmenuButton = new ButtonScreen(new Rectangle(860, 450, mainmenuText.Width, mainmenuText.Height), true);
            mainmenuButton.Load(Content, "mainmenubutton");

            resumeButton = new ButtonScreen(new Rectangle(850, 350, resumeText.Width, resumeText.Height), true);
            resumeButton.Load(Content, "resumebutton");

            playGameButton = new ButtonScreen(new Rectangle(850, 250, playGameText.Width, playGameText.Height), true);
            playGameButton.Load(Content, "playbutton");

            controlsButton = new ButtonScreen(new Rectangle(850, 350, controlsText.Width, controlsText.Height), true);
            controlsButton.Load(Content, "controlsbutton");

            quitButton = new ButtonScreen(new Rectangle(850, 450, quitText.Width, quitText.Height), true);
            quitButton.Load(Content, "quitbutton");


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
            mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();
            switch (CurrentScreen)
            {
                case MENU:
                    if (playGameButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        CurrentScreen = PLAYGAME;
                    else if (controlsButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        CurrentScreen = CONTROLS;
                    else if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        this.Exit();
                    break;
                case PAUZE:
                    if (resumeButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        CurrentScreen = PLAYGAME;
                    else if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        this.Exit();
                    break;
                case CONTROLS:
                    if (mainmenuButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        CurrentScreen = MENU;
                    break;
                case GAMEOVER:
                    if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        CurrentScreen = MENU;
                    break;
                case PLAYGAME:
                    if (keyboardState.IsKeyDown(Keys.Escape))
                        CurrentScreen = PAUZE;
                    camera.Follow(hero);
                    background.Update(hero.Position.X);
                    hero.Update(gameTime, collisionObjects, collider);
                    currentLevel.Update(gameTime, collisionObjects, collider);
                    break;
            }
            prevMouseState = mouseState;


           

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
            switch (CurrentScreen)
            {
                case MENU:
                    spriteBatch.Draw(mainScreenImage,Vector2.Zero, new Rectangle(0,0,mainScreenImage.Width,mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero,1f,SpriteEffects.None, 0f);
                    spriteBatch.Draw(playGameText, new Rectangle(850, 250, playGameText.Width, playGameText.Height), Color.White);
                    spriteBatch.Draw(controlsText, new Rectangle(850, 350, controlsText.Width, controlsText.Height), Color.White);
                    spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
                    break;
                case PAUZE:
                    spriteBatch.Draw(mainScreenImage, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(pausedText, new Rectangle(400, 135, pausedText.Width, pausedText.Height), Color.White);
                    spriteBatch.Draw(resumeText, new Rectangle(850, 350, playGameText.Width, playGameText.Height), Color.White);
                    spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
                    break;
                case CONTROLS:
                    spriteBatch.Draw(mainScreenImage, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(mainmenuText, new Rectangle(860, 450, mainmenuText.Width, mainmenuText.Height), Color.White);
                    spriteBatch.Draw(leftArrow, new Vector2(830, 250),null, Color.White, 0f, Vector2.Zero,0.5f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(rightArrow, new Vector2(1030, 250),null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(upArrow, new Vector2(930, 250),null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(movementText,"Movement : ", new Vector2(550, 270), Color.Black);
                    spriteBatch.DrawString(shootText,"Shoot : ", new Vector2(630,360), Color.Black);
                    spriteBatch.Draw(spaceTexture, new Vector2(840, 340),null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                    break;
                case GAMEOVER:
                    break;
                case PLAYGAME:
                    spriteBatch.End();
                    spriteBatch.Begin(transformMatrix: camera.Transform);
                    background.Draw(spriteBatch, GraphicsDevice);

                    currentLevel.DrawWorld(spriteBatch);
                    hero.Draw(spriteBatch);

                    spriteBatch.DrawString(scoreFont, "Stars collected : " + hero.amountOfStarsCollected, new Vector2(hero.Position.X - 830, -200), Color.Black);
                    spriteBatch.DrawString(scoreFont, "Number of lives : " + hero.AmountOfLives, new Vector2(hero.Position.X - 830, -150), Color.Black);


                    if (hero.amountOfStarsCollected == 30)
                    {
                        spriteBatch.DrawString(scoreFont, "You won! On to the next level.", new Vector2(hero.Position.X - 60, hero.Position.Y - 150), Color.Black);
                    }

                    break;
            }

            spriteBatch.End();

           

            base.Draw(gameTime);
        }
    }
}
