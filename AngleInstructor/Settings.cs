using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleInstructor
{
    public static class Settings
    {
        private static int delay = 10;
        public static int Delay
        {
            get
            {
                return delay;
            }
            set
            {
                delay = (!(value == 0)) ? value : 10;
            }
        }
    }
}
