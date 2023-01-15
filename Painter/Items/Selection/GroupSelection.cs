using System;
using System.Drawing;

namespace Painter
{
    internal class GroupSelection : Selection
    {
        public GroupSelection(Group group)
        {
            Item = group;
            UpdateMarkers();
        }
        public override bool Move(int x, int y)
        {
            int x_move = x - grabPoint.X;
            int y_move = y - grabPoint.Y;
            for (int i = 0; i < Markers.Count; i++)
            {
                Markers[i] = new Rectangle(Markers[i].X + x_move, Markers[i].Y + y_move, size_marker * 2, size_marker * 2);
            }
            UpdateFrame();

            foreach (Item item in ((Group)Item).Items)
            {
                Point point_1 = new Point(item.frame.x1 + x_move, item.frame.y1 + y_move);
                Point point_2 = new Point(item.frame.x2 + x_move, item.frame.y2 + y_move);
                item.frame = new Frame(point_1.X, point_1.Y, point_2.X, point_2.Y);
            }

            grabPoint.X = x;
            grabPoint.Y = y;

            return true;
        }
        public override bool Resize(int x, int y)
        {
            if (ActiveMark == -1) { return false; }
            int xMove = x - Markers[ActiveMark].X;
            int yMove = y - Markers[ActiveMark].Y;
            MoveMarkers(x, y);
            Frame oldFrame = Item.frame;
            UpdateFrame();

            // Пересчет фреймов элементов группы
            foreach (Item item in ((Group)Item).Items)
            {
                item.UpdateFrameWithRelativeFrame(Item.frame);
            }

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
            ActiveMark = -1;
            foreach (Item item in ((Group)Item).Items)
            {
                if (item.TryGrab(x, y))
                {
                    ChangeType = ChangeType.Move;
                    grabPoint = new Point(x, y);
                    return 2;
                }
            }
            if (TryGrabFromFrame(x, y))
            {
                ChangeType = ChangeType.Move;
                grabPoint = new Point(x, y);
                return 2;
            }
            return 0;
        }
    }
}
