namespace Omada
{
    public static class ShapeFactory
    {
        public static char[] CreateBox(char c, int rows, int cols)
        {
            char[] box = new char[rows * cols];
            for (int i = 0; i < rows * cols; i++)
            {
                box[i] = c;
            }
            return box;
        }

        public static char[] CreateCircle(char fillChar, int size, int radius)
        {
            char[] circle = new char[size * size];
            float centerX = (size - 1) / 2f;
            float centerY = (size - 1) / 2f;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    float directionX = x - centerX;
                    float directionY = y - centerY;
                    float distanceSq = directionX * directionX + directionY * directionY;

                    if (distanceSq <= radius * radius)
                    {
                        circle[y * size + x] = fillChar;
                    }
                    else
                    {
                        circle[y * size + x] = ' ';
                    }
                }
            }

            return circle;
        }

    }
}
