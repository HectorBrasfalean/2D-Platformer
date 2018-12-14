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
  
    interface IScreenState
    {
        
        void Load(ContentManager content, List<ICollide> collisionObjects, Level currentLevel,Background background);

        void Draw(SpriteBatch spriteBatch, Hero hero, Camera2D camera, Level currentLevel, GraphicsDevice graphicsDevice,Background background, SpriteFont scoreFont);

      
        void Update(GameTime gameTime, MouseState mouseState, MouseState prevMouseState, List<ICollide> collisionObjects, Hero hero, Camera2D camera, Collider collider, Level currentLevel,Background background);

    }

    abstract class ScreenState
    {
        public virtual void Load()
        {

        }
        public virtual void  Load(ContentManager content, List<ICollide> collisionObjects, Level currentLevel, Background background)
        {

        }

        public virtual void Draw()
        {
        }
        public virtual void  Draw(SpriteBatch spriteBatch, Hero hero, Camera2D camera, Level currentLevel, GraphicsDevice graphicsDevice, Background background, SpriteFont scoreFont) { }

        public virtual void Update()
        {

        }

        public virtual void Update(GameTime gameTime, MouseState mouseState, MouseState prevMouseState, List<ICollide> collisionObjects, Hero hero, Camera2D camera, Collider collider, Level currentLevel, Background background)
        {

        }


    }


}
