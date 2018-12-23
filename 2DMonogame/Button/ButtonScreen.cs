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
    /// <summary>
    /// Verantwwoordelijk voor de knoppen op het scherm
    /// </summary>
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

        /// <summary>
        /// Laad de texture voor de button op het scherm
        /// </summary>
        /// <param name="content">ContentManager die wordt gebruikt om de objecten te laden uit de content map</param>
        /// <param name="name">De naam van het bestand dat wordt geladen</param>
        public void Load(ContentManager content,string name)
        {
            texture = content.Load<Texture2D>(name);
        }

        /// <summary>
        /// Update de knop voor op het scherm, kijkt of er op geklikt wordt
        /// </summary>
        /// <param name="mousePos">Meegegeven positie van de muis waar geklikt is</param>
        /// <returns>Boolean die zegt of er op de knop is gedrukt</returns>
        public bool Update(Vector2 mousePos)
        {
            if (mousePos.X >= posSize.X && mousePos.X <= posSize.X + posSize.Width && mousePos.Y >= posSize.Y && mousePos.Y <= posSize.Y + posSize.Height)
                isClicked = true;
            else isClicked = false;
            if (!isAvailable)
                isClicked = false;
            return isClicked;
        }

        /// <summary>
        /// Tekent de knoppen op het scherm
        /// </summary>
        /// <param name="sprite">SpriteBatch object dat we gebruiken om dingen om het scherm te tekenen</param>
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
