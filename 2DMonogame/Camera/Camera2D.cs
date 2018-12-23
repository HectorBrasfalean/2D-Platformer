using Microsoft.Xna.Framework;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk elk camera object
    /// </summary>
    class Camera2D
    {
        public Matrix Transform { get; private set; }
        public float Zoom { get; set; }
        public int ScreenWidth;
        public int ScreenHeight;

        /// <summary>
        /// De camera volgt het object dat is meegegeven
        /// </summary>
        /// <param name="hero">Hero object dat we volgen</param>
        public void Follow(Hero hero)
        {
            Matrix scale = Matrix.CreateScale(Zoom, Zoom, 1);
            var position = Matrix.CreateTranslation(
                -hero.Position.X/2 - (hero.CollisionRectangle.X/2),
                -300,
                0);

            var offset = Matrix.CreateTranslation(
                ScreenWidth / 2 /Zoom , 
                ScreenHeight / 2 /Zoom, 
                0 );
            Transform = position * offset * scale;
        }
    }
}
