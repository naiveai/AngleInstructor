using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleInstructor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            double d;
            d = GeometryHelper.AngleBetweenTwoLines(new Point(0, 200), new Point(200, 200), new Point(400, 200));
            Console.WriteLine("D:" + d);

            d = GeometryHelper.AngleBetweenTwoLines(new Point(400, 200), new Point(200, 200), new Point(400, 200));
            Console.WriteLine("D:" + d);

            d = GeometryHelper.AngleBetweenTwoLines(new Point(200, 0), new Point(200, 200), new Point(400, 200));
            Console.WriteLine("D:" + d);

            d = GeometryHelper.AngleBetweenTwoLines(new Point(200, 400), new Point(200, 200), new Point(400, 200));
            Console.WriteLine("D:" + d);

            return;
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
    }
}
