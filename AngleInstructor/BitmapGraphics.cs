using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleInstructor
{
    class BitmapGraphics
    {
        public Graphics ImageGraphics { get; private set; }
        public Panel DrawingCanvas { get; private set; }

        public BitmapGraphics(Graphics imageGraphics, Panel drawingCanvas)
        {
            ImageGraphics = imageGraphics;
            DrawingCanvas = drawingCanvas;
        }

        public void Clear(Color color)
        {
            ImageGraphics.Clear(color);
            DrawingCanvas.Refresh();
        }

        public void DrawEllipse(Pen pen, int x, int y, int width, int height)
        {
            ImageGraphics.DrawEllipse(pen, x, y, width, height);
            DrawingCanvas.Refresh();
        }

        public void DrawLine(Pen pen, Point firstPoint, Point secondPoint)
        {
            ImageGraphics.DrawLine(pen, firstPoint, secondPoint);
            DrawingCanvas.Refresh();
        }

        public void DrawArc(Pen pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            ImageGraphics.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
            DrawingCanvas.Refresh();
        }

        public void DrawString(string name, Font font, Brush brush, Point point)
        {
            ImageGraphics.DrawString(name, font, brush, point);
            DrawingCanvas.Refresh();
        }
    }
}
