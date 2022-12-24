using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal class LineSelection : Selection
    {
        public LineSelection(Item item)
        {
            Item = item;
            markers.Add(new Rectangle(Item.frame.x1 - size_marker, Item.frame.y1 - size_marker, size_marker * 2, size_marker * 2));
            markers.Add(new Rectangle(Item.frame.x2 - size_marker, Item.frame.y2 - size_marker, size_marker * 2, size_marker * 2));
        }

        public override bool TryDragTo(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override bool TryGrab(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
