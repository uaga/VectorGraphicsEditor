using System.Collections.Generic;
using System.Drawing;

namespace Painter
{
    internal class Group : Item
    {
        List<Item> items;
        public List<Item> Items => items;
        public override void Draw(DrawSystem painter)
        {
            foreach (Item item in items)
            {
                item.Draw(painter);
            }
        }
        public Group(List<Item> getItems) : base(GetFrame(getItems))
        {
            items = new List<Item>(getItems);
            //Point ziro = new Point(frame.x1, frame.y1);
            //getItems.CopyTo(items);
            foreach (Item item in items)
            {
                //Frame relativeFrameItem = new Frame(item.frame.x1 - ziro.X, item.frame.y1 - ziro.Y, item.frame.x2 - ziro.X, item.frame.y2 - ziro.Y);
                item.SetRelativeFrame(frame);
            }
            //items.CopyTo(this.items);
        }
        static private Frame GetFrame(List<Item> items)
        {
            int xMin = 100000, yMin = 100000;
            int xMax = 0, yMax = 0;
            foreach (Item item in items)
            {
                if (item.frame.x1 < xMin)
                {
                    xMin = item.frame.x1;
                }
                if (item.frame.x2 > xMax)
                {
                    xMax = item.frame.x2;
                }
                if (item.frame.y1 < yMin)
                {
                    yMin = item.frame.y1;
                }
                if (item.frame.y2 > yMax)
                {
                    yMax = item.frame.y2;
                }
            }
            return new Frame(xMin, yMin, xMax, yMax);
        }

        public override bool TryGrab(int x, int y)
        {
            foreach (Item item in items)
            {
                if (item.TryGrab(x, y))
                {
                    return true;
                }
            }

            return TryGrabFromFrame(x, y);
        }

        public override Selection CreateSelection()
        {
            return new GroupSelection(this);
        }
    }
}
