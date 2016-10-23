using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            float aX2 = a.X + a.Width;
            float aY2 = a.Y + a.Height;

            float bX2 = b.X + b.Width;
            float bY2 = b.Y + b.Height;

            if ((bX2 >= a.X && b.X <= aX2) && (bY2 >= a.Y && b.Y <= aY2))
                return true;
            return false;
        }
    }
}
