using System.Drawing;

namespace Painter
{
    public class DrawSystem
    {
        Graphics graphics;
        Pen pen = new Pen(Color.Black);
        Brush brush =  new SolidBrush(Color.Black);
        public DrawSystem(Graphics gr)
        {
            this.graphics = gr;
        }
        public void Clear()
        {
            graphics.Clear(Color.White);
        }
        public void Line(int x1, int y1, int x2, int y2)
        {
            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);

            graphics.DrawLine(pen, p1, p2);
        }
        public void Rect(int x1, int y1, int x2, int y2)
        {
            graphics.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
            graphics.DrawRectangle(pen, x1, y1, x2 - x1, y2 - y1);
        }
        public int Width { set => pen.Width = value; }
        public Color SetPenColor { set => pen.Color = value; }
        public Color SetFillColor { set => ((SolidBrush)brush).Color = value; }
    }
}
