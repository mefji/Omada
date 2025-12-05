namespace Omada
{
    internal static class TextRenderer
    {
        private const int Width = 120;
        private const int Height = 30;

        public static void DrawText(char[] buffer, int x0, int y0, string text)
        {
            if (y0 < 0 || y0 >= Height) return;

            for (int i = 0; i < text.Length; i++)
            {
                int x = x0 + i;
                if (x < 0 || x >= Width)
                {
                    break;
                }

                buffer[y0 * Width + x] = text[i];
            }
        }
    }
}
