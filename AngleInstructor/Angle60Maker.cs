using System.Collections.Generic;
using System.Drawing;

namespace AngleInstructor
{
    class Angle60Maker : AngleMaker
    {
        private static Angle60Maker _angleMaker;

        private Angle60Maker() { }
        public static Angle60Maker GetInstance()
        {
            return _angleMaker ?? (_angleMaker = new Angle60Maker());
        }

        public override void MakeAngle(Controller controller, int speed)
        {
            controller.ClearTextBox();

            var anglePoints = MakeAngleForFurtherUse(controller, speed);

            // Angle is ready
            controller.AddDrawingInstructionText("∠ABC is the required 60° angle.");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Gold plating
            GeometryHelper.DrawArc(controller.DrawingGraphics, Color.CornflowerBlue, anglePoints[1], 30, 300, 60);
            GeometryHelper.AddDelayAsPerSpeed(speed);
            controller.DrawingGraphics.DrawString("60°", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(anglePoints[1].X + 35, anglePoints[1].Y - 35));

        }

        public override List<Point> MakeAngleForFurtherUse(Controller controller, int speed)
        {
            var pointB = new Point(100, 300);
            const int baseRadius = 200;

            // Draw Horizontal Base Line
            controller.AddDrawingInstructionText("Create one horizontal line.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawLine(controller.DrawingGraphics, Color.Red, pointB, new Point(500, pointB.Y));
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw point B
            controller.AddDrawingInstructionText("Label the starting point of this line B.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawPoint(controller.DrawingGraphics, Color.Blue, pointB, "B");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw large Arc from point B
            controller.AddDrawingInstructionText("Draw a large arc using point B as the center such that it intersects with the previously drawn line.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawArc(controller.DrawingGraphics, Color.DarkOrange, pointB, baseRadius, 280, 90);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw intersection point between Arc and base line
            var pointC = new Point(pointB.X + baseRadius, pointB.Y);
            controller.AddDrawingInstructionText("Label the intersection of the line and the arc drawn previously as C.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawPoint(controller.DrawingGraphics, Color.Blue, pointC, "C");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw Arc from Point C
            controller.AddDrawingInstructionText("Draw an arc with C as the center with the same radius as before such that it intersects with the previous arc. Label the intersection A.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            var arc1IntersectionPoint = GeometryHelper.MakeIntersectingArcAndReturnIntersectionPoint(controller.DrawingGraphics,
                pointB, baseRadius,
                pointC, baseRadius,
                30, Color.Firebrick, "A");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw Angle Line
            controller.AddDrawingInstructionText("Join A B.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawLine(controller.DrawingGraphics, Color.Brown, pointB, arc1IntersectionPoint);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            var anglePoints = new List<Point> { arc1IntersectionPoint, pointB, pointC };
            return anglePoints;
        }
    }
}
