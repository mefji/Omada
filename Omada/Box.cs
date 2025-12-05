using System.Numerics;

namespace Omada
{
    internal class Box : GameObject
    {
        const int ScreenWidth = 120;

        public Vector2 Position;
        public int Rows;
        public int Cols;
        public Vector2 Velocity;
        public char[] Shape;

        public Box(Vector2 position, int rows, int cols, Vector2 velocity, char c)
        {
            Position = position;
            Rows = rows;
            Cols = cols;
            Velocity = velocity;
            Shape = ShapeFactory.CreateBox(c, Rows, Cols);
        }

        public override void Update(double dt)
        {
            Position += Velocity;

            if (Position.X < 0)
            {
                Position = new Vector2(0, Position.Y);
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }

            if (Position.X + Cols >= ScreenWidth)
            {
                Position = new Vector2(ScreenWidth - Cols - 1, Position.Y);
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
        }

        public override void Render(char[] buffer)
        {
            ShapeRenderer.DrawShape(buffer, Position, Shape, Rows, Cols);
        }
    }
}
