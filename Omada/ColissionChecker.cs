using System.Numerics;

namespace Omada
{
    internal static class CollisionChecker
    {
        public static bool CheckCollision(Player player, Box box)
        {
            int rows = player.Rows;
            int cols = player.Cols;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    int playerX = (int)player.Position.X + x;
                    int playerY = (int)player.Position.Y + y;

                    if (playerX >= (int)box.Position.X && playerX < (int)box.Position.X + box.Cols)
                    {
                        if (playerY >= (int)box.Position.Y && playerY < (int)box.Position.Y + box.Rows)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
