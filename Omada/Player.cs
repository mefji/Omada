using System.Numerics;

namespace Omada
{
    public class Player : BoxCollider, IColliderCallback
    {
        public char[] Shape;
        public int Lives;

        public Player(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
            Lives = 3;
            Shape = ShapeFactory.CreateBox('@', (int)Size.Y, (int)Size.X);
        }

        public override void Update(float deltaTime)
        {

        }

        public void OnCollision(ICollider other)
        {
            if (!IsActive)
            {
                return;
            }

            if (Size.Y <= 0)
            {
                return;
            }

            if (Lives > 0)
            {
                Lives--;
            }

            Size = new Vector2(Size.X, Size.Y - 1);
            UpdateShape();

            if (Size.Y <= 0 || Lives <= 0)
            {
                IsActive = false;
                return;
            }

            if (Position.Y + Size.Y >= GameParameters.ScreenHeight)
            {
                Position = new Vector2(Position.X, GameParameters.ScreenHeight - Size.Y - 1);
            }

            if (Position.Y < 2)
            {
                Position = new Vector2(Position.X, 2);
            }
        }

        public void UpdateShape()
        {
            Shape = ShapeFactory.CreateBox('@', (int)Size.Y, (int)Size.X);
        }

        public override void Render(char[] buffer)
        {
            ShapeRenderer.DrawShape(buffer, Position, Shape, (int)Size.Y, (int)Size.X);
        }
    }
}
