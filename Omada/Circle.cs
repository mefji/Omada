using System.Numerics;

namespace Omada
{
    public class Circle : CircleCollider
    {
        public Vector2 Velocity;
        public char[] Shape;

        public Circle(Vector2 position, int radius, Vector2 velocity, char fillChar)
        {
            Position = position;
            Radius = radius;
            Velocity = velocity;
            Shape = ShapeFactory.CreateCircle(fillChar, radius * 2 + 1, radius);
        }

        public override void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;

            if (Position.X < Radius)
            {
                Position = new Vector2(Radius, Position.Y);
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }

            if (Position.X + Radius * 2 >= GameParameters.ScreenWidth)
            {
                Position = new Vector2(GameParameters.ScreenWidth - Radius * 2 - 1, Position.Y);
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
        }

        public override void Render(char[] buffer)
        {
            int size = Radius * 2 + 1;
            ShapeRenderer.DrawShape(buffer, Position, Shape, size, size);
        }
    }
}
