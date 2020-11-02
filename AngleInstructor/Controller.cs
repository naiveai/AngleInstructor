using System;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace AngleInstructor
{
    class Controller
    {
        private SpeechSynthesizer speaker;
        private readonly TextBox drawingInstructionsTextBox;
        public BitmapGraphics DrawingGraphics { get; private set; }

        public Controller(TextBox drawingInstructionsTextBox, BitmapGraphics drawingGraphics)
        {
            speaker = new SpeechSynthesizer();
            if (drawingInstructionsTextBox == null)
            {
                throw new ArgumentException("drawingInstructionsTextBox");
            }

            if (drawingGraphics == null)
            {
                throw new ArgumentException("drawingGraphics");
            }

            this.drawingInstructionsTextBox = drawingInstructionsTextBox;
            DrawingGraphics = drawingGraphics;
        }

        

        public void MakeAngle(Angle angle, int speed)
        {
            var angleMaker = GetAngleMaker(angle);
            angleMaker.MakeAngle(this, speed);
        }

        private AngleMaker GetAngleMaker(Angle angle)
        {
            switch (angle)
            {
                case Angle.Thirty:
                    return Angle30Maker.GetInstance();
                case Angle.FortyFive:
                    return Angle45Maker.GetInstance();
                case Angle.Sixty:
                    return Angle60Maker.GetInstance();
                case Angle.SeventyFive:
                    return Angle75Maker.GetInstance();
                case Angle.Ninety:
                    return Angle90Maker.GetInstance();
                case Angle.OneHundredAndThirtyFive:
                    return Angle135Maker.GetInstance();
                default:
                    throw new ArgumentOutOfRangeException("angle");
            }
        }

        public void AddDrawingInstructionText(string text)
        {
            drawingInstructionsTextBox.AppendText("- " + text + Environment.NewLine);
            speaker.Speak(text);
        }

        public void ClearTextBox()
        {
            drawingInstructionsTextBox.Clear();
        }
    }

    enum Angle
    {
        Thirty = 30,
        FortyFive = 45, 
        Sixty = 60,
        SeventyFive = 75,
        Ninety = 90,
        OneHundredAndThirtyFive = 135,
    }
}
