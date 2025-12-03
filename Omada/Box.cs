using System.Numerics;

namespace Omada
{
    internal class Box
    {
        public Vector2 Position;
        public int Rows;
        public int Cols;
        public Vector2 Velocity;
        public char[,] Shape;

        public Box(Vector2 position, int rows, int cols, Vector2 velocity, char c)
        {
            Position = position;
            Rows = rows;
            Cols = cols;
            Velocity = velocity;
            Shape = ShapeFactory.CreateBox(c, Rows, Cols);
        }
    }
}
