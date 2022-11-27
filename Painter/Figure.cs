

namespace Painter
{
    abstract class Figure : Item
    {
        PropSet propSet;
        public Figure(Frame frame, PropSet propSet) : base(frame)
        {
            this.propSet = propSet;
        }

        public override void Draw(DrawSystem painter)
        {
            propSet.Apply(painter);
            Drowgeometry(painter);
        }

        protected abstract void Drowgeometry(DrawSystem painter);
    }

    class Line : Figure
    {
        public Line(Frame frame, PropSet propSet) : base(frame, propSet)
        {
        }
        protected override void Drowgeometry(DrawSystem painter)
        {
            painter.Line(frame.x1, frame.y1, frame.x2, frame.y2);
        }
    }
    class Rect : Figure
    {
        public Rect(Frame frame, PropSet propSet) : base(frame, propSet)
        {

        }
        protected override void Drowgeometry(DrawSystem painter)
        {
            painter.Rect(frame.x1, frame.y1, frame.x2, frame.y2);
        }
    }
}
