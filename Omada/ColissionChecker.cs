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
                    int px = (int)player.Position.X + x;
                    int py = (int)player.Position.Y + y;

                    if (px >= (int)box.Position.X && px < (int)box.Position.X + box.Cols)
                    {
                        if (py >= (int)box.Position.Y && py < (int)box.Position.Y + box.Rows)
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
