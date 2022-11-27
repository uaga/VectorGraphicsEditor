using System.Collections.Generic;
using System.Drawing;

namespace Painter
{
    public abstract class Propertie
    {
        public abstract void Apply(DrawSystem painter);
    }
    public class LineProps : Propertie, ILineProperties
    {
        public int Width { get; set; }
        public Color Color { get; set; }

        public LineProps(Color color, int width)
        {
            Color = color;
            Width = width;
        }

        public override void Apply(DrawSystem painter)
        {
            painter.SetPenColor = Color;
            painter.Width = Width;
        }
        
    }
    public class FillProps : Propertie, IFillProperties
    {
        public Color Color { get; set; }
        public FillProps(Color fillColor)
        {
            Color = fillColor;
        }

        public override void Apply(DrawSystem painter)
        {
            painter.SetFillColor = Color;
        }
    }
    public class PropSet : List<Propertie>
    {
        public void Apply(DrawSystem painter)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Apply(painter);
            }
        }

    }

}