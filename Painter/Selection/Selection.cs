using System.Collections.Generic;
using System.Drawing;

namespace Painter
{
    enum ChangeType { Move, Resize, }
    abstract class Selection
    {
        readonly protected int size_marker = 5;
        protected ChangeType ChangeType { get; set; }
        protected int ActiveMark = -1;
        protected Point grabPpoint= new Point(-1, -1);
        protected Item Item;
        protected List<Rectangle> markers = new List<Rectangle>();
        public abstract bool TryGrab(int x, int y);
        public abstract bool TryDragTo(int x, int y);
        //public void ReleaseGrab()
        //{
        //    ActiveMark= Rectangle.Empty;
        //}
        public void Draw(DrawSystem drawSystem)
        {
            drawSystem.DrawSelection(markers);
            drawSystem.DrawFrame(Item.frame);
        }
    }
}
