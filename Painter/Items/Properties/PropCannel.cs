﻿
using System.Drawing;

namespace Painter
{
    interface ILineProperties
    {
        int Width { get; set; }
        Color Color { get; set; }
    }
    interface IFillProperties
    {
        Color Color { get; set; }
    }
    interface IGraphicsProperties
    {
        ILineProperties lineProperties { get; set; }
        IFillProperties fillProperties { get; set; }
        void ApplyProperties();
    }
    internal class GraphicsProperties : IGraphicsProperties
    {
        ItemFactory factory;
        public ILineProperties lineProperties { get; set; } = new LineProps(Color.Black, 1);
        public IFillProperties fillProperties { get; set; } = new FillProps(Color.Empty);
        public GraphicsProperties(ItemFactory factory)
        {
            this.factory = factory;
        }
        public void ApplyProperties()
        {
            factory.ApplyProperties(lineProperties, fillProperties);
        }


    }
}
