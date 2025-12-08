using System.Numerics;

namespace Omada
{
    public static class CollisionChecker
    {
        public static bool CheckCollision(BoxCollider firstBox, BoxCollider secondBox)
        {
            float firstBoxLeft = firstBox.Position.X;
            float firstBoxRight = firstBox.Position.X + firstBox.Size.X;
            float firstBoxTop = firstBox.Position.Y;
            float firstBoxBottom = firstBox.Position.Y + firstBox.Size.Y;

            float secondBoxLeft = secondBox.Position.X;
            float secondBoxRight = secondBox.Position.X + secondBox.Size.X;
            float secondBoxTop = secondBox.Position.Y;
            float secondBoxBottom = secondBox.Position.Y + secondBox.Size.Y;

            return firstBoxLeft < secondBoxRight && firstBoxRight > secondBoxLeft && firstBoxTop < secondBoxBottom && firstBoxBottom > secondBoxTop;
        }

        public static bool CheckCollision(BoxCollider box, CircleCollider circle)
        {
            float boxLeft = box.Position.X;
            float boxRight = box.Position.X + box.Size.X;
            float boxTop = box.Position.Y;
            float boxBottom = box.Position.Y + box.Size.Y;

            float circleCenterX = circle.Position.X + circle.Radius;
            float circleCenterY = circle.Position.Y + circle.Radius;

            float closestPointX = Math.Clamp(circleCenterX, boxLeft, boxRight);
            float closestPointY = Math.Clamp(circleCenterY, boxTop, boxBottom);

            float differenceX = circleCenterX - closestPointX;
            float differenceY = circleCenterY - closestPointY;

            float squaredDistanceToBox = differenceX * differenceX + differenceY * differenceY;
            float squaredRadius = circle.Radius * circle.Radius;

            return squaredDistanceToBox <= squaredRadius;
        }

        public static bool CheckCollision(CircleCollider firstCircle, CircleCollider secondCircle)
        {
            float firstCircleCenterX = firstCircle.Position.X + firstCircle.Radius;
            float firstCircleCenterY = firstCircle.Position.Y + firstCircle.Radius;

            float secondCircleCenterX = secondCircle.Position.X + secondCircle.Radius;
            float secondCircleCenterY = secondCircle.Position.Y + secondCircle.Radius;

            float differenceX = firstCircleCenterX - secondCircleCenterX;
            float differenceY = firstCircleCenterY - secondCircleCenterY;

            float squaredDistanceBetweenCenters = differenceX * differenceX + differenceY * differenceY;
            float radiusSum = firstCircle.Radius + secondCircle.Radius;
            float squaredRadiiSum = radiusSum * radiusSum;

            return squaredDistanceBetweenCenters <= squaredRadiiSum;
        }
    }
}
