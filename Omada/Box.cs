using System.Numerics;

namespace Omada
{
    public class Box : BoxCollider
    {
        public Vector2 Velocity;
        public char[] Shape;

        public Box(Vector2 position, Vector2 size, Vector2 velocity, char c)
        {
            Position = position;
            Size = size;
            Velocity = velocity;
            Shape = ShapeFactory.CreateBox(c, (int)size.Y, (int)size.X);
        }

        public override void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;

            if (Position.X < 0)
            {
                Position = new Vector2(0, Position.Y);
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }

            if (Position.X + Size.X >= GameParameters.ScreenWidth)
            {
                Position = new Vector2(GameParameters.ScreenWidth - Size.X - 1, Position.Y);
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
        }

        public override void Render(char[] buffer)
        {
            ShapeRenderer.DrawShape(buffer, Position, Shape, (int)Size.Y, (int)Size.X);
        }
    }
}
