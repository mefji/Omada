namespace Omada
{
    internal static class TextRenderer
    {
        private const int Width = 120;
        private const int Height = 30;

        public static void DrawText(char[] buffer, int startX, int startY, string text)
        {
            if (startY < 0 || startY >= Height) return;

            for (int i = 0; i < text.Length; i++)
            {
                int x = startX + i;
                if (x < 0 || x >= Width)
                {
                    break;
                }

                buffer[startY * Width + x] = text[i];
            }
        }
    }
}
