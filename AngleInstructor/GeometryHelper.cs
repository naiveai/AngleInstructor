using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using GeoLib;


namespace AngleInstructor
{
    static class GeometryHelper
    {
        public static void DrawPoint(BitmapGraphics g, Color color, Point point, string name)
        {
            var pen = new Pen(color, 3);
            g.DrawEllipse(pen, point.X - 2, point.Y - 2, 4, 4);
            MakePointName(g, point, new Font("Arial", 10, FontStyle.Regular), name);
        }

        public static void DrawLine(BitmapGraphics g, Color color, Point firstPoint, Point secondPoint)
        {
            var pen = new Pen(color, 3);
            g.DrawLine(pen, firstPoint, secondPoint);
        }

        public static void DrawArc(BitmapGraphics g, Color color, Point center, int radius, int startAngle, int sweepAngle)
        {
            var pen = new Pen(color, 3);
            g.DrawArc(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2, startAngle, sweepAngle);
        }

        public static void MakePointName(BitmapGraphics g, Point pointToBeNamed, Font font, string name)
        {
           var locationString = new Point(pointToBeNamed.X - 1, pointToBeNamed.Y + 5);
           g.DrawString(name, font, Brushes.Black, locationString);
        }

        public static void AddDelayAsPerSpeed(int speed)
        {
            int delay;
            switch (speed)
            {
                case 0:
                    delay = 8000;
                    break;
                case 1:
                    delay = 2000;
                    break;
                case 2:
                    delay = 500;
                    break;
                default:
                    delay = 2000;
                    break;
            }
              Thread.Sleep(delay);
              Application.DoEvents();
        }

        public static Point? GetTopIntersectionPoint(Point center1, double radius1, Point center2, double radius2)
        {
            var center1C2DPoint = new C2DPoint(center1.X, center1.Y);
            var circle1 = new C2DCircle(center1C2DPoint, radius1);

            var center2C2DPoint = new C2DPoint(center2.X, center2.Y);
            var circle2 = new C2DCircle(center2C2DPoint, radius2);

            var intersectionPts = new List<C2DPoint>();

            bool isIntersecting = circle1.Crosses(circle2, intersectionPts);

            if (!isIntersecting)
            {
                return null;
            }

            if (intersectionPts.Count == 1)
            {
                return new Point((int) intersectionPts[0].x, (int) intersectionPts[0].y);
            }
            else
            {
                Point point1 = new Point((int) intersectionPts[0].x, (int) intersectionPts[0].y);
                Point point2 = new Point((int) intersectionPts[1].x, (int) intersectionPts[1].y);

                if (point1.Y < point2.Y)
                {
                    return point1;
                }
                return point2;
            }
        }

        public static Point MakeIntersectingArcAndReturnIntersectionPoint(BitmapGraphics g, Point existingCenter, int existignRadius,
            Point arcCenter, int arcRadius, int arcSweepAngle, Color arcColor, string intersectionPointName)
        {
            var intersectionPoint = GetArcsIntersectionPoint(existingCenter, existignRadius, arcCenter, arcRadius);

            int arcStartAngle = AngleBetweenTwoLines(intersectionPoint, arcCenter, new Point(arcCenter.X + 10, arcCenter.Y));

            if (intersectionPoint.Y < arcCenter.Y)
            {
                arcStartAngle = 360 - arcStartAngle;
            }


            DrawArc(g, arcColor, arcCenter, arcRadius, arcStartAngle - (arcSweepAngle / 2), arcSweepAngle);
            DrawPoint(g, Color.Blue, intersectionPoint, intersectionPointName);

            return intersectionPoint;
        }

        public static Point GetArcsIntersectionPoint(Point existingCenter, int existignRadius, Point arcCenter, int arcRadius)
        {
            Point? tempIntersectionPoint = GetTopIntersectionPoint(existingCenter, existignRadius, arcCenter, arcRadius);
            if (tempIntersectionPoint == null)
            {
                throw new Exception("No intersection points found.");
            }

            return (Point)tempIntersectionPoint;
        }

        public static int AngleBetweenTwoLines(Point point1, Point commonPoint, Point point2)
        {
            var a = (double) commonPoint.X - point1.X;
            var b = (double) commonPoint.Y - point1.Y;
            var c = (double) commonPoint.X - point2.X;
            var d = (double) commonPoint.Y - point2.Y;

            var mag_v1 = Math.Sqrt(a * a + b * b);
            var mag_v2 = Math.Sqrt(c * c + d * d);

            var cos_angle = (a * c + b * d) / (mag_v1 * mag_v2);
            var angle = Math.Acos(cos_angle);

            return (int) (angle * 180.0 / Math.PI);
        }

        public static Point BisectAngleUsingArcs(List<Point> existingAnglePoints, BitmapGraphics g, Color arcColor, Color lineColor, string intersectionPointName)
        {
            var firstPoint = existingAnglePoints[0];
            var secondPoint = existingAnglePoints[2];

            var pointDistance = GetPointDistance(firstPoint, secondPoint);
            var radius = (int)(pointDistance * 0.75);

            Point? tempIntersectionPoint = GetTopIntersectionPoint(firstPoint, radius, secondPoint, radius);
            if (tempIntersectionPoint == null)
            {
                throw new Exception("No intersection points found.");
            }
            Point intersectionPoint = (Point) tempIntersectionPoint;

            int angleForFirstPoint = AngleBetweenTwoLines(intersectionPoint, firstPoint, new Point(firstPoint.X + 10, firstPoint.Y));
            if (intersectionPoint.Y < firstPoint.Y)
            {
                angleForFirstPoint = 360 - angleForFirstPoint;
            }

            int angleForSecondPoint = AngleBetweenTwoLines(intersectionPoint, secondPoint, new Point(secondPoint.X + 10, secondPoint.Y));
            if (intersectionPoint.Y < secondPoint.Y)
            {
                angleForSecondPoint = 360 - angleForSecondPoint;
            }

            DrawArc(g, arcColor, firstPoint, radius, angleForFirstPoint - 10, 20);
            DrawArc(g, arcColor, secondPoint, radius, angleForSecondPoint - 10, 20);
            DrawPoint(g, Color.Blue, intersectionPoint, intersectionPointName);

            // Draw Angle Line
            DrawLine(g, lineColor, intersectionPoint, existingAnglePoints[1]);
            
            return intersectionPoint;

        }

        public static double GetPointDistance(Point firstPoint, Point secondPoint)
        {
            double changeInX = Math.Abs(firstPoint.X - secondPoint.X);
            double changeInY = Math.Abs(firstPoint.Y - secondPoint.Y);

            // using formula distance = sqrt(x^2 + y^2) where x, y is change in x and y
            return Math.Sqrt((changeInX*changeInX) + (changeInY*changeInY)); 
        }
    }

    enum Direction
    {
        Top,
        Right,
        Bottom,
        Left,
        TopAndRight,
        TopAndLeft,
        BottomAndRight,
        BottomAndLeft, 
    }
}
