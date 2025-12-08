using System.Numerics;

namespace Omada
{
    public static class ShapeRenderer
    {
        private const int Width = 120;
        private const int Height = 30;

        public static void DrawShape(char[] buffer, Vector2 position, char[] shape, int rows, int cols)
        {
            int startX = (int)position.X;
            int startY = (int)position.Y;

            if (startX < 0)
            {
                startX = 0;
            }

            if (startY < 0)
            {
                startY = 0;
            }

            if (startX >= Width || startY >= Height)
            {
                return;
            }

            for (int y = 0; y < rows; y++)
            {
                int currentY = startY + y;

                if (currentY < 0) 
                {
                    continue;
                }

                if (currentY >= Height) 
                {
                    break;
                } 

                for (int x = 0; x < cols; x++)
                {
                    int currentX = startX + x;
                    if (currentX < 0 || currentX >= Width)
                    {
                        continue;
                    } 
                    buffer[currentY * Width + currentX] = shape[y * cols + x];
                }
            }
        }
    }
}
