using System.Collections.Generic;
using System.Drawing;

namespace Painter
{
    abstract class Selection
    {
        readonly protected int size_marker = 5;
        protected Item Item;
        protected List<Rectangle> markers = new List<Rectangle>();
        public abstract bool TryGrab(int x, int y);
        public abstract bool TryDragTo(int x, int y);
        public void ReleaseGrab()
        {

        }
        public void Draw(DrawSystem drawSystem)
        {
            drawSystem.DrawSelection(markers);
            drawSystem.DrawFrame(Item.frame);
        }
    }
}
