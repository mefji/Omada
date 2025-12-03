using System.Numerics;

namespace Omada
{
    internal static class CollisionChecker
    {
        public static bool CheckCollision(Player dog, Box box)
        {
            int dogRows = dog.Rows;
            int dogCols = dog.Cols;

            for (int y = 0; y < dogRows; y++)
            {
                for (int x = 0; x < dogCols; x++)
                {
                    int px = (int)dog.Position.X + x;
                    int py = (int)dog.Position.Y + y;

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
