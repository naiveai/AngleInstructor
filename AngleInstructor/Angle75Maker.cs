using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AngleInstructor
{
    internal class Angle75Maker : AngleMaker
    {
        private static Angle75Maker _angleMaker;

        private Angle75Maker()
        {
        }

        public static Angle75Maker GetInstance()
        {
            return _angleMaker ?? (_angleMaker = new Angle75Maker());
        }

        public override void MakeAngle(Controller controller, int speed)
        {
            controller.ClearTextBox();
            var anglePoints = MakeAngleForFurtherUse(controller, speed);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Angle is ready
            controller.AddDrawingInstructionText("∠QBC is the required 75° angle.");

            // Gold plating
            GeometryHelper.DrawArc(controller.DrawingGraphics, Color.CadetBlue, anglePoints[1], 30, 285, 75);
            controller.DrawingGraphics.DrawString("75°", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(anglePoints[1].X + 40, anglePoints[1].Y - 20));
        }

        public override List<Point> MakeAngleForFurtherUse(Controller controller, int speed)
        {
            var angle90Points = Angle90Maker.GetInstance().MakeAngleForFurtherUse(controller, speed);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            var pointB = angle90Points[1];
            var pointC = angle90Points[2];
            var baseRadius = (int) GeometryHelper.GetPointDistance(pointB, pointC);

            // Get the C-Arc and B-Semi-Circle intersection point
            var arc1IntersectionPoint = GeometryHelper.GetArcsIntersectionPoint(pointB, baseRadius, pointC, baseRadius);

            // Draw Angle Line
            controller.AddDrawingInstructionText("Join B X. ∠XBC is a 60° Angle");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawLine(controller.DrawingGraphics, Color.Brown, pointB, arc1IntersectionPoint);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            angle90Points[0] = new Point(angle90Points[0].X, angle90Points[1].Y - baseRadius);
            GeometryHelper.DrawPoint(controller.DrawingGraphics, Color.Blue, angle90Points[0], "T");

            controller.AddDrawingInstructionText("Bisect ∠XBA on the points that intersect from the very first semicircle.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            angle90Points[2] = arc1IntersectionPoint;
            var intersectionPoint = GeometryHelper.BisectAngleUsingArcs(angle90Points, controller.DrawingGraphics,
                Color.BlueViolet, Color.Chartreuse, "Q");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            List<Point> anglePoints;
            anglePoints = new List<Point> {intersectionPoint, pointB, pointC};
            return anglePoints;
        }
    }
}
