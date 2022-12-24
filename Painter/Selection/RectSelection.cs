using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal class RectSelection
    {
        Rect Rect { get; set; }
        public RectSelection(Rect rect)
        {
            Rect = rect;
        }
    }
}
