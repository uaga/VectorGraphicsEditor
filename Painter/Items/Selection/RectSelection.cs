using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal class RectSelection : Selection
    {
        Rect Rect { get; set; }
        public RectSelection(Rect rect)
        {
            Rect = rect;
            Markers.Add(new Rectangle(Rect.frame.x1 - size_marker, Rect.frame.y1 - size_marker, size_marker * 2, size_marker * 2));
            Markers.Add(new Rectangle(Rect.frame.x1 - size_marker, Rect.frame.y2 - size_marker, size_marker * 2, size_marker * 2));
            Markers.Add(new Rectangle(Rect.frame.x2 - size_marker, Rect.frame.y2 - size_marker, size_marker * 2, size_marker * 2));
            Markers.Add(new Rectangle(Rect.frame.x2 - size_marker, Rect.frame.y1 - size_marker, size_marker * 2, size_marker * 2));
        }
        public override int TryGrab(int x, int y)
        {
            throw new NotImplementedException();
        }
        public override bool Move(int x, int y)
        {
            throw new NotImplementedException();
        }
        public override bool Resize(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
