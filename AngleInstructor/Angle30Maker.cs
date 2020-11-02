using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AngleInstructor
{
    class Angle30Maker : AngleMaker
    {
        private static Angle30Maker _angleMaker;

        private Angle30Maker() { }
        public static Angle30Maker GetInstance()
        {
            return _angleMaker ?? (_angleMaker = new Angle30Maker());
        }

        public override void MakeAngle(Controller controller, int speed)
        {
            controller.ClearTextBox();

            var anglePoints = MakeAngleForFurtherUse(controller, speed);
            GeometryHelper.AddDelayAsPerSpeed(speed);
            controller.AddDrawingInstructionText("Bisect this angle, and name the intersection while bisecting Q.");

            // Angle is ready
            controller.AddDrawingInstructionText("∠QBC is the required 30° angle.");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Gold plating
            GeometryHelper.DrawArc(controller.DrawingGraphics, Color.CornflowerBlue, anglePoints[1], 30, 330, 30);
            GeometryHelper.AddDelayAsPerSpeed(speed);
            controller.DrawingGraphics.DrawString("30°", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(anglePoints[1].X + 40, anglePoints[1].Y - 20));

        }

        public override List<Point> MakeAngleForFurtherUse(Controller controller, int speed)
        {
            var anglePoints = Angle60Maker.GetInstance().MakeAngleForFurtherUse(controller, speed);
            Point intersectionPoint = GeometryHelper.BisectAngleUsingArcs(anglePoints, controller.DrawingGraphics, Color.BlueViolet, Color.Brown, "Q");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            anglePoints[0] = intersectionPoint;
            return anglePoints;
        }
    }
}
                 

