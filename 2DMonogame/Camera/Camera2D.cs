using Microsoft.Xna.Framework;

namespace _2DMonogame
{
    class Camera2D
    {
        public Matrix Transform { get; private set; }
        public float Zoom { get; set; }
        public int ScreenWidth;
        public int ScreenHeight;
        public void Follow(Hero hero)
        {
            Matrix scale = Matrix.CreateScale(Zoom, Zoom, 1);
            var position = Matrix.CreateTranslation(
                -hero.Position.X/2 - (hero.CollisionRectangle.X/2),
                0,
                0);

            var offset = Matrix.CreateTranslation(
                ScreenWidth / 2 /Zoom , 
                ScreenHeight / 2 /Zoom, 
                0 );
            Transform = position * offset * scale;
        }
    }
}
