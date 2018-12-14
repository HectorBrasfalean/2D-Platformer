using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Button;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DMonogame.Screens
{
    class MainMenuScreen : ScreenState
    {
        Texture2D playGameText,quitText,controlsText,mainScreenImage;
        ButtonScreen playGameButton,controlsButton,quitButton;
        ScreenManager screenManager;
        public MainMenuScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Draw(SpriteBatch spriteBatch, Hero hero, Camera2D camera, Level currentLevel, GraphicsDevice graphicsDevice,Background background, SpriteFont scoreFont)
        {
    
        }

        public void Load(ContentManager content, List<ICollide> collisionObjects, Level currentLevel,Background background)
        {

        }

        public void Update(GameTime gameTime, MouseState mouseState, MouseState prevMouseState, List<ICollide> collisionObjects, Hero hero, Camera2D camera, Collider collider, Level currentLevel,Background background)
        {

        }
    }
}
