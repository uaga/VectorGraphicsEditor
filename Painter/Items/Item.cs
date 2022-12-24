using System;
using System.Collections.Generic;

namespace Painter
{
    abstract class Item
    {
        public Frame frame;
        public Item(Frame frame)
        {
            this.frame = frame;
        }
        abstract public void Draw(DrawSystem painter);

        public abstract bool TryGrab(int x, int y);
        public abstract Selection CreateSelection();
    }
}
