using System.Collections.Generic;
using System.Drawing;

namespace AngleInstructor
{
    class Angle90Maker : AngleMaker
    {
        private static Angle90Maker _angleMaker;
        
        private Angle90Maker() { }

        public static Angle90Maker GetInstance()
        {
            return _angleMaker ?? (_angleMaker = new Angle90Maker());
        }

        public override void MakeAngle(Controller controller, int speed)
        {
            controller.ClearTextBox();
  
            var anglePoints = MakeAngleForFurtherUse(controller, speed);

            // Angle is ready
            controller.AddDrawingInstructionText("∠ABC is the required 90° angle.");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Gold plating
            GeometryHelper.DrawArc(controller.DrawingGraphics, Color.CornflowerBlue, anglePoints[1], 30, 270, 90);
            GeometryHelper.AddDelayAsPerSpeed(speed);
            controller.DrawingGraphics.DrawString("90°", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(anglePoints[1].X + 35, anglePoints[1].Y - 35));
        }

        public override List<Point> MakeAngleForFurtherUse(Controller controller, int speed)
        {
            var pointB = new Point(300, 350);
            const int baseRadius = 200;

            // Draw Base Line
            controller.AddDrawingInstructionText("Create one horizontal line.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawLine(controller.DrawingGraphics, Color.Red, new Point(50, 350), new Point(550, 350));
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw point B
            controller.AddDrawingInstructionText("Select one point B around the middle of the line.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawPoint(controller.DrawingGraphics, Color.Blue, pointB, "B");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw semi circle
            controller.AddDrawingInstructionText("Draw a semi-circle above the line using this point as the center.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawArc(controller.DrawingGraphics, Color.Salmon, pointB, baseRadius, 170, 200);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw First Arc Center point (Semi circle and line intersection point)
            var pointC = new Point(pointB.X + baseRadius, pointB.Y);
            controller.AddDrawingInstructionText("Label the intersection of the line and the semi-circle C.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawPoint(controller.DrawingGraphics, Color.Blue, pointC, "C");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw First Arc
            controller.AddDrawingInstructionText("Use the point C as the center to draw a short arc so that it intersects with the semi-circle. Name the intersection X.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            Point arc1IntersectionPoint = GeometryHelper.MakeIntersectingArcAndReturnIntersectionPoint(controller.DrawingGraphics,
                pointB, baseRadius,
                pointC, baseRadius,
                30, Color.Firebrick, "X");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw Second Arc
            controller.AddDrawingInstructionText("Use the point X as the center to draw a short arc so that it intersects with the semi-circle. Name the intersection Y.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            Point arc2IntersectionPoint = GeometryHelper.MakeIntersectingArcAndReturnIntersectionPoint(controller.DrawingGraphics,
                pointB, baseRadius,
                arc1IntersectionPoint, baseRadius,
                30, Color.Firebrick, "Y");
            GeometryHelper.AddDelayAsPerSpeed(speed);


            // Draw Third Arc (top) from arc1IntersectionPoint
            controller.AddDrawingInstructionText("Use point X as the center to draw a short arc above the semi-circle. The radius of this arc should be more than half of the distance between X and Y.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawArc(controller.DrawingGraphics, Color.BlueViolet, arc1IntersectionPoint, 120, 200, 40);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw Fourth Arc (top) from arc2IntersectionPoint
            controller.AddDrawingInstructionText("Use point Y as the center to draw a short arc above the semi-circle intersecting the first arc. The radius of this arc should be the same.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            var arc4IntersectionPoint = GeometryHelper.MakeIntersectingArcAndReturnIntersectionPoint(controller.DrawingGraphics,
                arc1IntersectionPoint, 120,
                arc2IntersectionPoint, 120,
                40, Color.BlueViolet, "A");
            GeometryHelper.AddDelayAsPerSpeed(speed);

            // Draw Angle Line
            controller.AddDrawingInstructionText("Join A-B.");
            GeometryHelper.AddDelayAsPerSpeed(speed);
            GeometryHelper.DrawLine(controller.DrawingGraphics, Color.Brown, pointB, arc4IntersectionPoint);
            GeometryHelper.AddDelayAsPerSpeed(speed);

            var anglePoints = new List<Point> { arc4IntersectionPoint, pointB, pointC };
            return anglePoints;
        }
    }
}

