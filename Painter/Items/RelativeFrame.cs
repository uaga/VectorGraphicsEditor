using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal class RelativeFrame
    {
        public double x1;
        public double y1;
        public double lenght;
        public double width;
        public RelativeFrame(double x1, double y1, double lenght, double width)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.lenght = lenght;
            this.width = width;
        }
    }
}
