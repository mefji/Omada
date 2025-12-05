using System.Numerics;

namespace Omada
{
    internal static class ShapeRenderer
    {
        private const int Width = 120;
        private const int Height = 30;

        public static void DrawShape(char[] buffer, Vector2 position, char[] shape, int rows, int cols)
        {
            int x0 = (int)position.X;
            int y0 = (int)position.Y;

            if (x0 < 0)
            {
                x0 = 0;
            }

            if (y0 < 0)
            {
                y0 = 0;
            }

            if (x0 >= Width || y0 >= Height)
            {
                return;
            }

            for (int y = 0; y < rows; y++)
            {
                int cy = y0 + y;

                if (cy < 0) 
                {
                    continue;
                }

                if (cy >= Height) 
                {
                    break;
                } 

                for (int x = 0; x < cols; x++)
                {
                    int cx = x0 + x;
                    if (cx < 0 || cx >= Width)
                    {
                        continue;
                    } 
                    buffer[cy * Width + cx] = shape[y * cols + x];
                }
            }
        }
    }
}
