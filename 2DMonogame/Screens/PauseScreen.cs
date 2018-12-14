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
    class PauseScreen : ScreenState
    {
        Texture2D mainScreenImage, pausedText, resumeText, quitText;
        ButtonScreen resumeButton, quitButton;
        ScreenManager screenManager;
        public PauseScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Draw()
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
