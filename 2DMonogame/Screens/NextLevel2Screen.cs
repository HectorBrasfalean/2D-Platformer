﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DMonogame.Screens
{
    class NextLevel2Screen : IScreenState
    {
        ScreenManager screenManager;
        public NextLevel2Screen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Camera2D camera, Hero hero, Background background, Level currentLevel)
        {
            throw new NotImplementedException();
        }

        public void Load(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, Camera2D camera, Hero hero, List<ICollide> collisionObjects, Background background, Collider collider, Level currentLevel)
        {
            throw new NotImplementedException();
        }
    }
}