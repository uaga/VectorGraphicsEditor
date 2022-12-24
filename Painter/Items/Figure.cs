

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
        public override Selection CreateSelection()
        {
            return new LineSelection(this);
        }

        public override bool TryGrab(int x, int y)
        {
            double k = (double)(frame.y2 - frame.y1) / (frame.x2 - frame.x1);
            double b = frame.y2 - k * frame.x2;
            if (y <= k * x + b + 5 && y >= k * x + b - 5)
            {
                return true;
            }
            return false;
        }
    }
    class Rect : Figure
    {
        public Rect(Frame frame, PropSet propSet) : base(frame, propSet)
        {

        }

        public override Selection CreateSelection()
        {
            throw new System.NotImplementedException();
        }

        public override bool TryGrab(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        protected override void Drowgeometry(DrawSystem painter)
        {
            painter.Rect(frame.x1, frame.y1, frame.x2, frame.y2);
        }
    }
}
