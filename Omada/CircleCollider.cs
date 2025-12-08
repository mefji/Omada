using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Omada
{
    public abstract class CircleCollider : GameObject, ICollider
    {
        public Vector2 Position {  get; set; }
        public int Radius { get; set; }

        public bool IsCollidingWith(ICollider other)
        {
            if (other is BoxCollider boxCollider)
            {
                return CollisionChecker.CheckCollision(boxCollider, this);
            }

            if (other is CircleCollider circleCollider)
            {
                return CollisionChecker.CheckCollision(this, circleCollider);
            }

            return false;
        }
    }
}
