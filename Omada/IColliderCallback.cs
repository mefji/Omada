using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omada
{
    public interface IColliderCallback
    {
        void OnCollision(ICollider other);
    }
}
