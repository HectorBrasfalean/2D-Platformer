using _2DMonogame.Button;
using _2DMonogame.Characters;
using _2DMonogame.Collision;
using _2DMonogame.Screens;
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
        bool escapeReleased = true;
        int currentScreen;
        const int MAINMENU = 0, PLAY = 1, CONTROLS = 2, QUIT = 3, PAUSED = 4, GAMEOVER = 5;
        ButtonScreen controlsButton,mainMenuButton,playGameButton,quitButton,resumeButton,restartButton;
        Texture2D controlsText, leftArrow, mainMenuText, mainScreenImage,controlsScreen,pausedScreen,gameOverScreen,levelCompleteScreen,pausedText,playGameText,quitText,resumeText,rightArrow,upArrow,spaceTexture,restartText;
        SpriteFont scoreFont,shootText,movementText;
        ScreenManager screenManager;
        MouseState mouseState;
        MouseState prevMouseState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Background background;
        Collider collider;
        int ScreenWidth,ScreenHeight;
        Hero hero;
        Level currentLevel;
        Camera2D camera;
        List<ICollide> collisionObjects;

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
            screenManager = new ScreenManager(this);

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
            LoadFonts();
            LoadTextures();
            LoadButtons();


            //screenManager.Load(Content,collisionObjects,currentLevel,background);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            currentLevel.CreateWorld(Content, collisionObjects);
        }

        /// <summary>
        /// Laad alle spriteFonts
        /// </summary>
        private void LoadFonts()
        {
            movementText = Content.Load<SpriteFont>("movementText");
            shootText = Content.Load<SpriteFont>("shootText");
            scoreFont = Content.Load<SpriteFont>("Points");
        }

        /// <summary>
        /// Laad alle textures
        /// </summary>
        private void LoadTextures()
        {
            background.backgroundTexture = Content.Load<Texture2D>("AangepasteBackground");
            mainScreenImage = Content.Load<Texture2D>("mainMenu");
            leftArrow = Content.Load<Texture2D>("leftArrow");
            rightArrow = Content.Load<Texture2D>("rightArrow");
            upArrow = Content.Load<Texture2D>("upArrow");
            spaceTexture = Content.Load<Texture2D>("space");
            mainMenuText = Content.Load<Texture2D>("mainMenuButton");
            controlsText = Content.Load<Texture2D>("controlsbutton");
            playGameText = Content.Load<Texture2D>("playbutton");
            quitText = Content.Load<Texture2D>("quitbutton");
            resumeText = Content.Load<Texture2D>("resumebutton");
            restartText = Content.Load<Texture2D>("restartbutton");
            levelCompleteScreen = Content.Load<Texture2D>("levelCompleteMenu");
            gameOverScreen = Content.Load<Texture2D>("gameOverMenu");
            pausedScreen = Content.Load<Texture2D>("pausedMenu");
            controlsScreen = Content.Load<Texture2D>("controlsMenu");
        }

        /// <summary>
        /// Laad alle verschillende buttons voor op de schermen
        /// </summary>
        private void LoadButtons()
        {
            restartButton = new ButtonScreen(new Rectangle(850, 350, restartText.Width, restartText.Height), true);
            restartButton.Load(Content, "restartbutton");

            resumeButton = new ButtonScreen(new Rectangle(850, 250, resumeText.Width, resumeText.Height), true);
            resumeButton.Load(Content, "resumebutton");

            playGameButton = new ButtonScreen(new Rectangle(850, 250, playGameText.Width, playGameText.Height), true);
            playGameButton.Load(Content, "playbutton");

            controlsButton = new ButtonScreen(new Rectangle(850, 350, controlsText.Width, controlsText.Height), true);
            controlsButton.Load(Content, "controlsbutton");

            quitButton = new ButtonScreen(new Rectangle(850, 450, quitText.Width, quitText.Height), true);
            quitButton.Load(Content, "quitbutton");

            mainMenuButton = new ButtonScreen(new Rectangle(860, 450, mainMenuText.Width, mainMenuText.Height), true);
            mainMenuButton.Load(Content, "mainmenubutton");
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
            switch (currentScreen)
            {
                case PLAY:
                    this.IsMouseVisible = false;
                    if (keyboardState.IsKeyDown(Keys.Escape) && escapeReleased)
                    {
                        currentScreen = PAUSED;
                        escapeReleased = false;
                    }
                    if (keyboardState.IsKeyUp(Keys.Escape))
                        escapeReleased = true;
                    camera.Follow(hero);
                    background.Update(hero.Position.X);
                    hero.Update(gameTime, collisionObjects, collider);
                    currentLevel.Update(gameTime, collisionObjects, collider);
                    if (hero.AmountOfLives == 0 && hero.currentAnimation.CurrentFrame == hero.deathAnimation.frames[hero.deathAnimation.frames.Count - 1])
                        currentScreen = GAMEOVER;
                    break;
                case PAUSED:
                    this.IsMouseVisible = true;
                    if (keyboardState.IsKeyDown(Keys.Escape) && escapeReleased)
                    {
                        currentScreen = PLAY;
                        escapeReleased = false;
                    }
                    if (keyboardState.IsKeyUp(Keys.Escape))
                        escapeReleased = true;
                    if (resumeButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        currentScreen = PLAY;
                    else if (restartButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        currentScreen = PLAY;
                        LoadNewLevel(new Level1(Content));
                    }
                    else if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        this.Exit();
                    break;
                case CONTROLS:
                    if (mainMenuButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        currentScreen = MAINMENU;
                    break;
                case MAINMENU:
                    if (playGameButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        currentScreen = PLAY;
                        LoadNewLevel(new Level1(Content));
                    }
                    else if (controlsButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        currentScreen = CONTROLS;
                    else if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        this.Exit();
                    break;
                case GAMEOVER:
                    this.IsMouseVisible = true;
                    if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        this.Exit();
                    else if (mainMenuButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        currentScreen = MAINMENU;
                    else if (restartButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        currentScreen = PLAY;
                        LoadNewLevel(new Level1(Content));
                    }
                    break;
            }
            //screenManager.Update(gameTime, mouseState, prevMouseState,collisionObjects,hero,camera,collider,currentLevel,background);
            prevMouseState = mouseState;
            base.Update(gameTime);
        }

        /// <summary>
        /// Laad een nieuw level
        /// </summary>
        /// <param name="newLevel">Bepaalt welk level er geladen wordt</param>
        private void LoadNewLevel(Level newLevel)
        {
            currentLevel = newLevel;
            collisionObjects.Clear();
            currentLevel.CreateWorld(Content, collisionObjects);
            hero.amountOfStarsCollected = 0;
            hero.AmountOfLives = 3;
            hero.RespawnLocation = new Vector2(150, 600);
            hero.Position = hero.RespawnLocation;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (currentScreen)
            {
                case MAINMENU:
                    spriteBatch.Draw(mainScreenImage, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(playGameText, new Rectangle(850, 250, playGameText.Width, playGameText.Height), Color.White);
                    spriteBatch.Draw(controlsText, new Rectangle(850, 350, controlsText.Width, controlsText.Height), Color.White);
                    spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
                    break;
                case CONTROLS:
                    spriteBatch.Draw(controlsScreen, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    mainMenuButton.PosSize = new Rectangle(860, 450, mainMenuText.Width, mainMenuText.Height);
                    spriteBatch.Draw(mainMenuText, new Rectangle(860, 450, mainMenuText.Width, mainMenuText.Height), Color.White);
                    spriteBatch.Draw(leftArrow, new Vector2(830, 250), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(rightArrow, new Vector2(1030, 250), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(upArrow, new Vector2(930, 250), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(movementText, "Movement : ", new Vector2(550, 270), Color.Black);
                    spriteBatch.DrawString(shootText, "Shoot : ", new Vector2(630, 360), Color.Black);
                    spriteBatch.Draw(spaceTexture, new Vector2(840, 340), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                    break;
                case PAUSED:
                    spriteBatch.Draw(pausedScreen, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(resumeText, new Rectangle(850, 250, resumeText.Width, resumeText.Height), Color.White);
                    restartButton.PosSize = new Rectangle(850, 350, restartText.Width, restartText.Height);
                    spriteBatch.Draw(restartText, new Rectangle(850, 350, restartText.Width, restartText.Height), Color.White);
                    spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
                    break;
                case PLAY:
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
                case GAMEOVER:
                    spriteBatch.Draw(gameOverScreen, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    restartButton.PosSize = new Rectangle(850, 250, restartText.Width, restartText.Height);
                    spriteBatch.Draw(restartText, new Rectangle(850, 250, restartText.Width, restartText.Height), Color.White);
                    mainMenuButton.PosSize = new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height);
                    spriteBatch.Draw(mainMenuText, new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height), Color.White);
                    spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
