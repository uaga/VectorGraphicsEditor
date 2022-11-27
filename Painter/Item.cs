using System.Collections.Generic;

namespace Painter
{
    abstract class Item
    {
        protected Frame frame;
        public Item(Frame frame)
        {
            this.frame = frame;
        }
        abstract public void Draw(DrawSystem painter);
    }
}
