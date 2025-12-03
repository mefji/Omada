namespace Omada
{
    internal static class ShapeFactory
    {
        public static char[,] CreateBox(char c, int rows, int cols)
        {
            char[,] box = new char[rows, cols];
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    box[y, x] = c;
                }
            }
            return box;
        }
    }
}
