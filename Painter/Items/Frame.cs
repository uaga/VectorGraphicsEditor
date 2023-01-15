using System.Drawing;

namespace Painter
{
    public class Frame
    {
        public int x1 { set; get; }
        public int y1 { set; get; }
        public int x2 { set; get; }
        public int y2 { set; get; }
        public int lenght { get; set; }
        public int width { get; set; }
        public Frame(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            lenght = x2 - x1;
            width = y2 - y1;
        }
        public Rectangle GetRect()
        {
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }
    }
}
