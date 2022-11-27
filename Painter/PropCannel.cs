using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ILineProperties lineProperties { get; set; }
        public IFillProperties fillProperties { get; set; }
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
