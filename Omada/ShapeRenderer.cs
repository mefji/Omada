namespace Omada
{
    internal static class ShapeRenderer
    {
        public static void DrawShape(char[,] buffer, System.Numerics.Vector2 position, char[,] shape)
        {
            int rows = shape.GetLength(0);
            int cols = shape.GetLength(1);

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

            int height = buffer.GetLength(0);
            int width = buffer.GetLength(1);

            if (x0 >= width || y0 >= height)
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

                if (cy >= height)
                {
                    break;
                }

                for (int x = 0; x < cols; x++)
                {
                    int cx = x0 + x;
                    if (cx < 0 || cx >= width)
                    {
                        continue;
                    }
                    buffer[cy, cx] = shape[y, x];
                }
            }
        }
    }
}
