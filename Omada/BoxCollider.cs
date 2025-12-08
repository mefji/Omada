using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Omada
{
    public abstract class BoxCollider : GameObject, ICollider
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public bool IsCollidingWith(ICollider other)
        {
           if (other is BoxCollider boxCollider)
            {
                return CollisionChecker.CheckCollision(this, boxCollider);
            }

           if (other is CircleCollider circleCollider)
            {
                return CollisionChecker.CheckCollision(this, circleCollider);
            }

            return false;
        }
    }
}
