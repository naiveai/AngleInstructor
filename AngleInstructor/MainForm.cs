using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace AngleInstructor 
{
    public partial class MainForm : Form
    {
        private BitmapGraphics g;
        private Bitmap drawingCanvasBitmap;
        private readonly Controller controller;

        public MainForm() 
        {
            InitializeComponent();

            #region Initializing graphics & controller
            
            drawingCanvasBitmap = new Bitmap(drawingCanvas.Width, drawingCanvas.Height);
            g = new BitmapGraphics(Graphics.FromImage(drawingCanvasBitmap), drawingCanvas);
            controller = new Controller(InstructionText, g);
            #endregion

            #region Initializing angle drop down
            var angleValues = new Dictionary<Angle, int>
            {
                {Angle.Thirty, 30},
                {Angle.FortyFive, 45},
                {Angle.Sixty, 60},
                {Angle.SeventyFive, 75},
                {Angle.Ninety, 90},
                {Angle.OneHundredAndThirtyFive, 135},
            };
            AngleDropDown.DataSource = new BindingSource(angleValues, null);
            AngleDropDown.DisplayMember = "Value";
            AngleDropDown.ValueMember = "Key";
            #endregion
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            controller.MakeAngle((Angle) AngleDropDown.SelectedValue, SpeedTrackBar.Value);
        }
        
        #region Invalidating code (basically to stop the flicker, and avoid the 'I'm gone if you drag me off the screen' effect)
        

        private void drawingCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawingCanvasBitmap, new Point(0, 0));
        }
         
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void RunFrame_Tick(object sender, EventArgs e)
        {
            drawingCanvas.Refresh();
        }

        private void MainForm_HelpRequested(object sender, EventArgs e)
        {
            MessageBox.Show("Select the angle for intsruction in the drop down." + Environment.NewLine +
                "Set the speed: Very Slow, Meduim, or Fast (Fast Recommended)" + Environment.NewLine +
                "Press the 'Instruct Me!' button to get instructions." + Environment.NewLine +
                "The steps will be shown in the a canvas, will" + Environment.NewLine +
                "be spoken and will be shown in the text box on the right.", "Help");
        }

        // NOTE: The previous method has been copied from
        // Stack Overflow, big thanks to Hans Passant;
        // here's the description for why it works:
        // "The big difference between this technique and Winform's double-buffering support 
        // is that Winform's version only works on one control at at time. You will still see each individual control paint itself. 
        // Which can look like a flicker effect as well, 
        // particularly if the unpainted control rectangle contrasts badly with the window's background."

        #endregion
    }
}
