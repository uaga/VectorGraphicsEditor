namespace Painter
{
    abstract class Item
    {
        public Frame frame;
        RelativeFrame RelativeFrame { get; set; }
        public Item(Frame frame)
        {
            this.frame = frame;
        }
        abstract public void Draw(DrawSystem painter);
        public void SetRelativeFrame(Frame parentFrame)
        {
            RelativeFrame = new RelativeFrame((frame.x1 - parentFrame.x1) / (parentFrame.lenght * 1.0), (frame.y1 - parentFrame.y1) / (parentFrame.width * 1.0), (frame.x2 - frame.x1) / (parentFrame.lenght * 1.0), (frame.y2 - frame.y1) / (parentFrame.width * 1.0));
        }
        public void UpdateFrameWithRelativeFrame(Frame parentFrame)
        {
            int x1 = (int)(parentFrame.x1 + (RelativeFrame.x1 * parentFrame.lenght));
            int y1 = (int)(parentFrame.y1 + (RelativeFrame.y1 * parentFrame.width));
            int x2 = (int)(x1 + parentFrame.lenght * RelativeFrame.lenght);
            int y2 = (int)(y1 + parentFrame.width * RelativeFrame.width);
            frame = new Frame(x1, y1, x2, y2);
        }
        public abstract bool TryGrab(int x, int y);
        public abstract Selection CreateSelection();
        /// <summary>
        /// Возвращает <b>try</b> если точка на линии фрейма с погрешность size_marker
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool TryGrabFromFrame(int x, int y)
        {
            int size_marker = 5;
            if (frame.x1 - size_marker < x & frame.x1 + size_marker > x & frame.y1 - size_marker < y & frame.y2 + size_marker > y) { return true; }
            else if (frame.x2 - size_marker < x & frame.x2 + size_marker > x & frame.y1 - size_marker < y & frame.y2 + size_marker > y) { return true; }
            else if (frame.y1 - size_marker < y & frame.y1 + size_marker > y & frame.x1 - size_marker < x & frame.x2 + size_marker > x) { return true; }
            else if (frame.y2 - size_marker < y & frame.y2 + size_marker > y & frame.x1 - size_marker < x & frame.x2 + size_marker > x) { return true; }
            else { return false; }
        }
    }
}
