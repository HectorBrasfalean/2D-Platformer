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

namespace _2DMonogame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        bool escapeReleased = true,loadNextLevel;
        int currentScreen;
        const int MAINMENU = 0, PLAY = 1, CONTROLS = 2, QUIT = 3, PAUSED = 4, GAMEOVER = 5, LEVEL1COMPLETE = 6, LEVEL2COMPLETE = 7;
        ButtonScreen controlsButton,mainMenuButton,playGameButton,quitButton,resumeButton,restartButton,nextLevelButton;
        Texture2D controlsText, leftArrow, mainMenuText, mainScreenImage,controlsImage,pausedImage,gameOverImage,level1CompleteScreen,
            playGameText,quitText,resumeText,rightArrow,upArrow,spaceTexture,restartText,level2CompleteScreen,heart,star,
            nextLevelTexture;
        SpriteFont scoreFont,shootText,movementText;
        ScreenManager screenManager;
        MouseState mouseState,prevMouseState;
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
            level1CompleteScreen = Content.Load<Texture2D>("level1CompleteMenu");
            level2CompleteScreen = Content.Load<Texture2D>("level2CompleteMenu");
            gameOverImage = Content.Load<Texture2D>("gameOverMenu");
            pausedImage = Content.Load<Texture2D>("pausedMenu");
            controlsImage = Content.Load<Texture2D>("controlsMenu");
            nextLevelTexture = Content.Load<Texture2D>("nextlevelbutton");
            heart = Content.Load<Texture2D>("heart");
            star = Content.Load<Texture2D>("star");
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

            nextLevelButton = new ButtonScreen(new Rectangle(860, 250, nextLevelTexture.Width, nextLevelTexture.Height), true);
            nextLevelButton.Load(Content, "nextlevelbutton");

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
                    foreach (ButtonNextLevel nextLevelButton in collisionObjects.OfType<ButtonNextLevel>())
                    {
                        if (hero.CollisionRectangle.Intersects(nextLevelButton.CollisionRectangle) && hero.Velocity.Y > 5)
                            loadNextLevel = true;
                    }
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
                    if (loadNextLevel)
                    {
                        loadNextLevel = false;
                        if (currentLevel is Level1)
                            currentScreen = LEVEL1COMPLETE;
                        else
                            currentScreen = LEVEL2COMPLETE;
                    }

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
                        LoadLevel(new Level1(Content), new Vector2(150, 600));
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
                        LoadLevel(new Level2(Content), new Vector2(150, 250));
                        //LoadLevel(new Level1(Content), new Vector2(150, 600));
                        ResetHeroCollectedStars();
                        ResetHeroLives();
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
                        LoadLevel(new Level1(Content), new Vector2(150, 600));
                        ResetHeroCollectedStars();
                        ResetHeroLives();
                    }
                    break;
                case LEVEL1COMPLETE:
                    this.IsMouseVisible = true;
                    if (nextLevelButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        currentScreen = PLAY;
                        hero.Position = new Vector2();
                        LoadLevel(new Level2(Content), new Vector2(150, 200));
                        ResetHeroCollectedStars();
                    }
                    else if (mainMenuButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        currentScreen = MAINMENU;
                    else if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        this.Exit();
                    break;
                case LEVEL2COMPLETE:
                    this.IsMouseVisible = true;
                    if (mainMenuButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        currentScreen = MAINMENU;
                    else if (quitButton.Update(new Vector2(mouseState.X, mouseState.Y)) == true && mouseState != prevMouseState && mouseState.LeftButton == ButtonState.Pressed)
                        this.Exit();
                    break;
            }
            prevMouseState = mouseState;
            base.Update(gameTime);
        }

        /// <summary>
        /// Laad nieuw level
        /// </summary>
        /// <param name="nextLevel">het volgende level dat geladen moet worden</param>
        /// <param name="spawnPosHero">de spawn locatie van de hero</param>
        private void LoadLevel(Level nextLevel,Vector2 spawnPosHero)
        {
            currentLevel = nextLevel;
            collisionObjects.Clear();
            currentLevel.CreateWorld(Content, collisionObjects);
            SetHeroSpawnLocation(spawnPosHero);
        }

        /// <summary>
        /// Reset het aantal levens van de hero
        /// </summary>
        private void ResetHeroLives()
        {
            hero.AmountOfLives = 3;
        }

        /// <summary>
        /// Zet de hero zijn spawnlocatie op een bepaalde locatie
        /// </summary>
        /// <param name="spawnPos">de positie waar de hero zou moeten spawnen</param>
        private void SetHeroSpawnLocation(Vector2 spawnPos)
        {
            hero.RespawnLocation = spawnPos;
            hero.Position = hero.RespawnLocation;
        }

        private void ResetHeroCollectedStars()
        {
            hero.amountOfStarsCollected = 0;
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
                    spriteBatch.Draw(controlsImage, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
                    spriteBatch.Draw(pausedImage, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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

                    spriteBatch.Draw(star, new Vector2(hero.Position.X - 830, -220), null, Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(scoreFont, hero.amountOfStarsCollected + "x", new Vector2(hero.Position.X - 770, -210), Color.Black);
                    spriteBatch.Draw(heart, new Vector2(hero.Position.X - 830, -150),null, Color.AliceBlue, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(scoreFont, hero.AmountOfLives + "x", new Vector2(hero.Position.X - 770, -150), Color.Black);

                    //if (hero.amountOfStarsCollected == 30)
                    //{
                    //    spriteBatch.DrawString(scoreFont, "You won! On to the next level", new Vector2(hero.Position.X - 125, hero.Position.Y - 150), Color.Black);
                    //}
                    break;
                case GAMEOVER:
                    spriteBatch.Draw(gameOverImage, Vector2.Zero, new Rectangle(0, 0, mainScreenImage.Width, mainScreenImage.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    restartButton.PosSize = new Rectangle(850, 250, restartText.Width, restartText.Height);
                    spriteBatch.Draw(restartText, new Rectangle(850, 250, restartText.Width, restartText.Height), Color.White);
                    mainMenuButton.PosSize = new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height);
                    spriteBatch.Draw(mainMenuText, new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height), Color.White);
                    spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
                    break;
                case LEVEL1COMPLETE:
                    spriteBatch.Draw(level1CompleteScreen, Vector2.Zero, new Rectangle(0, 0, level1CompleteScreen.Width, level1CompleteScreen.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(shootText, "Stars collected : " + hero.amountOfStarsCollected + " / 30", new Vector2(300, 350), Color.Black);
                    spriteBatch.Draw(nextLevelTexture, new Rectangle(850, 250, nextLevelTexture.Width, nextLevelTexture.Height), Color.White);
                    mainMenuButton.PosSize = new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height);
                    spriteBatch.Draw(mainMenuText, new Rectangle(850, 350, mainMenuText.Width, mainMenuText.Height), Color.White);
                    spriteBatch.Draw(quitText, new Rectangle(850, 450, quitText.Width, quitText.Height), Color.White);
                    break;
                case LEVEL2COMPLETE:
                    spriteBatch.Draw(level2CompleteScreen, Vector2.Zero, new Rectangle(0, 0, level2CompleteScreen.Width, level2CompleteScreen.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
