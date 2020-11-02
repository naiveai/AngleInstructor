using System.Collections.Generic;
using System.Drawing;

namespace AngleInstructor
{
    class Angle45Maker : AngleMaker
    {
        private static Angle45Maker _angleMaker;

        private Angle45Maker() { }
        public static Angle45Maker GetInstance()
        {
            return _angleMaker ?? (_angleMaker = new Angle45Maker());
        }

        public override void MakeAngle(Controller controller, int speed)
        {
            controller.ClearTextBox();

            var anglePoints = MakeAngleForFurtherUse(controller, speed);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Angle is ready
            controller.AddDrawingInstructionText("∠QBC is the required 45° angle.");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Gold plating
            GeometryHelper.DrawArc(controller.DrawingGraphics, Color.CadetBlue, anglePoints[1], 30, 315, 45);
            GeometryHelper.AddDelayAsPerSpeed(speed);
            controller.DrawingGraphics.DrawString("45°", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(anglePoints[1].X + 40, anglePoints[1].Y - 20));
        }

        public override List<Point> MakeAngleForFurtherUse(Controller controller, int speed)
        {
            var anglePoints = Angle90Maker.GetInstance().MakeAngleForFurtherUse(controller, speed);
            GeometryHelper.AddDelayAsPerSpeed(speed);
            controller.AddDrawingInstructionText("Bisect ∠ABC and name the intersection point while bisecting Q.");
            var intersectionPoint = GeometryHelper.BisectAngleUsingArcs(anglePoints, controller.DrawingGraphics, Color.BlueViolet, Color.Chartreuse, "Q");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            anglePoints[0] = intersectionPoint;
            return anglePoints;
        }
    }
}
                 

