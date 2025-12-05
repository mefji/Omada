namespace Omada
{
    internal static class ShapeFactory
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
    }
}
