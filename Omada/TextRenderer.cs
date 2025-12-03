namespace Omada
{
    internal static class TextRenderer
    {
        public static void DrawText(char[,] buffer, int x0, int y0, string text)
        {
            int height = buffer.GetLength(0);
            int width = buffer.GetLength(1);

            if (y0 < 0 || y0 >= height)
            {
                return;
            }

            for (int i = 0; i < text.Length; i++)
            {
                int x = x0 + i;
                if (x < 0 || x >= width)
                {
                    break;
                }
                buffer[y0, x] = text[i];
            }
        }
    }
}
