using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AngleInstructor
{
    abstract class AngleMaker
    {
        public abstract void MakeAngle(Controller controller, int speed);
        public abstract List<Point> MakeAngleForFurtherUse(Controller controller, int speed);
    }
}
