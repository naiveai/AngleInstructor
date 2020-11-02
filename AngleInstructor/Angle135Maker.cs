using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AngleInstructor
{
    class Angle135Maker : AngleMaker
    {
        private static Angle135Maker _angleMaker;

        private Angle135Maker() { }

        public static Angle135Maker GetInstance()
        {
            return _angleMaker ?? (_angleMaker = new Angle135Maker());
        }

        public override void MakeAngle(Controller controller, int speed)
        {
            controller.ClearTextBox();
            var anglePoints = MakeAngleForFurtherUse(controller, speed);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Angle is ready
            controller.AddDrawingInstructionText("∠QBC is the required 135° angle.");
            // Gold plating
            GeometryHelper.DrawArc(controller.DrawingGraphics, Color.CadetBlue, anglePoints[1], 30, 225, 135);
            controller.DrawingGraphics.DrawString("135°", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(anglePoints[1].X + 30, anglePoints[1].Y - 40));
        }

        public override List<Point> MakeAngleForFurtherUse(Controller controller, int speed)
        {
            
            var angle90Points = Angle90Maker.GetInstance().MakeAngleForFurtherUse(controller, speed);

            controller.AddDrawingInstructionText("Bisect the left side angle with the intersections of the very first semicircle, this will get you a 45° angle.");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            var pointB = angle90Points[1];
            var baseRadius = (int)GeometryHelper.GetPointDistance(pointB, angle90Points[2]);

            angle90Points[2] = new Point(pointB.X - baseRadius, pointB.Y);
            GeometryHelper.DrawPoint(controller.DrawingGraphics, Color.Blue, angle90Points[2], "D");

            angle90Points[0] = new Point(angle90Points[0].X, angle90Points[1].Y - baseRadius);
            GeometryHelper.DrawPoint(controller.DrawingGraphics, Color.Blue, angle90Points[0], "T");

            var intersectionPoint = GeometryHelper.BisectAngleUsingArcs(angle90Points, controller.DrawingGraphics,
               Color.BlueViolet, Color.Chartreuse, "Q");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            return new List<Point> {intersectionPoint, pointB, angle90Points[2]};
        }
    }
}
