using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omada
{
    public interface ICollider
    {
        bool IsCollidingWith(ICollider other);
    }
}

