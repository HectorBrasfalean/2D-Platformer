using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame.Button
{
    class ButtonScreen
    {
        private Rectangle posSize;

        public Rectangle PosSize
        {
            get { return posSize; }
            set { posSize = value; }
        }

        private bool isClicked;

        public bool IsClicked
        {
            get { return isClicked; }
            set { isClicked = value; }
        }

        private bool isAvailable;

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        Texture2D texture;

        public ButtonScreen()
        {
            posSize = new Rectangle(100, 100, 100, 50);
            isClicked = false;
            isAvailable = true;
        }

        public ButtonScreen(Rectangle rec,bool available)
        {
            posSize = rec;
            this.isAvailable = available;
            isClicked = false;
        }

        public void Load(ContentManager content,string name)
        {
            texture = content.Load<Texture2D>(name);
        }

        public bool Update(Vector2 mousePos)
        {
            if (mousePos.X >= posSize.X && mousePos.X <= posSize.X + posSize.Width && mousePos.Y >= posSize.Y && mousePos.Y <= posSize.Y + posSize.Height)
                isClicked = true;
            else isClicked = false;
            if (!isAvailable)
                isClicked = false;
            return isClicked;
        }
        
        public void Draw(SpriteBatch sprite)
        {
            Color color = Color.White;
            if (!isAvailable)
                color = new Color(50, 50, 50);
            if (isClicked)
                color = Color.Green;
            sprite.Draw(texture, posSize, color);
        }

    }
}
