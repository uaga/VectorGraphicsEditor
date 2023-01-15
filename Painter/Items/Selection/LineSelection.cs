using System.Drawing;

namespace Painter
{
    internal class LineSelection : Selection
    {
        public LineSelection(Item item)
        {
            Item = item;
            UpdateMarkers();
            //markers.Add(new Rectangle(Item.frame.x1 - size_marker, Item.frame.y1 - size_marker, size_marker * 2, size_marker * 2));
            //markers.Add(new Rectangle(Item.frame.x2 - size_marker, Item.frame.y2 - size_marker, size_marker * 2, size_marker * 2));
        }
        //public override void UpdateMarkers()
        //{
        //    markers.Add(new Rectangle(Item.frame.x1 - size_marker, Item.frame.y1 - size_marker, size_marker * 2, size_marker * 2));
        //    markers.Add(new Rectangle(Item.frame.x2 - size_marker, Item.frame.y2 - size_marker, size_marker * 2, size_marker * 2));
        //}
        public override bool Move(int x, int y)
        {
            int x_move = x - grabPoint.X;
            int y_move = y - grabPoint.Y;
            for (int i = 0; i < Markers.Count; i++)
            {
                Markers[i] = new Rectangle(Markers[i].X + x_move, Markers[i].Y + y_move, size_marker * 2, size_marker * 2);
            }
            UpdateFrame();
            grabPoint = new Point(x, y);
            return true;
        }
        public override bool Resize(int x, int y)
        {
            if (ActiveMark == -1) { return false; }
            MoveMarkers(x, y);
            UpdateFrame();
            UpdateMarkers();
            return true;
        }
        public override int TryGrab(int x, int y)
        {
            for (int i = 0; i < Markers.Count; i++)
            {
                if (Markers[i].Contains(x, y))
                {
                    ChangeType = ChangeType.Resize;
                    ActiveMark = i;
                    return 1;
                }
            }
            if (TryGrabFromFrame(x, y))
            {
                ChangeType = ChangeType.Move;
                grabPoint = new Point(x, y);
                return 2;
            }
            double k = (double)(Item.frame.y2 - Item.frame.y1) / (Item.frame.x2 - Item.frame.x1);
            double b = Item.frame.y2 - k * Item.frame.x2;
            if (y <= k * x + b + size_marker && y >= k * x + b - size_marker)
            {
                ChangeType = ChangeType.Move;
                grabPoint = new Point(x, y);
                return 2;
            }
            ActiveMark = -1;
            return 0;
        }
    }
}
