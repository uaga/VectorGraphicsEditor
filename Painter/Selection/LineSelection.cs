using System.Drawing;
using System.Drawing.Printing;

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
            switch (ChangeType)
            {
                case ChangeType.Move:
                    return Move(x, y);
                case ChangeType.Resize:
                    return Resize(x, y);
                default:
                    return false;
            }
        }
        bool Move(int x, int y)
        {
            for (int i = 0; i < markers.Count; i++)
            {
                var p = markers[i];
                p.X += x - grabPpoint.X;
                p.Y += y - grabPpoint.Y;
                markers[i] = p;
            }
            Item.frame = new Frame(markers[0].X + size_marker, markers[0].Y + size_marker, markers[1].X + size_marker, markers[1].Y + size_marker);
            grabPpoint.X = x;
            grabPpoint.Y = y;
            return true;
        }
        bool Resize(int x, int y)
        {
            if (ActiveMark == -1) { return false; }
            Rectangle r = markers[ActiveMark];
            r.X = x - size_marker;
            r.Y = y - size_marker;
            markers[ActiveMark] = r;
            Item.frame = new Frame(markers[0].X + size_marker, markers[0].Y + size_marker, markers[1].X + size_marker, markers[1].Y + size_marker);
            return true;
        }
        public override bool TryGrab(int x, int y)
        {
            for (int i = 0; i < markers.Count; i++)
            {
                if (markers[i].Contains(x, y))
                {
                    ChangeType = ChangeType.Resize;
                    ActiveMark = i;
                    return true;
                }
            }
            double k = (double)(Item.frame.y2 - Item.frame.y1) / (Item.frame.x2 - Item.frame.x1);
            double b = Item.frame.y2 - k * Item.frame.x2;
            if (y <= k * x + b + 5 && y >= k * x + b - 5)
            {
                ChangeType = ChangeType.Move;
                grabPpoint.X = x;
                grabPpoint.Y = y;
                return true;
            }
            ActiveMark = -1;
            return false;
        }
    }
}
