using System.Numerics;

namespace Omada
{
    internal class Player : GameObject
    {
        public Vector2 Position;
        public int Rows;
        public int Cols;
        public char[] Shape;

        public Player(Vector2 position, int rows, int cols)
        {
            Position = position;
            Rows = rows;
            Cols = cols;
            Shape = ShapeFactory.CreateBox('@', Rows, Cols);
        }

        public void UpdateShape()
        {
            Shape = ShapeFactory.CreateBox('@', Rows, Cols);
        }

        public override void Render(char[] buffer)
        {
            ShapeRenderer.DrawShape(buffer, Position, Shape, Rows, Cols);
        }
    }
}
