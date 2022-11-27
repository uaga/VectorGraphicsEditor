using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    class ItemStore : List<Item>
    {

    }
    class ItemFactory
    {
        ItemStore items;
        LineProps lineProps { get; set; } = new LineProps(Color.Black, 1);
        FillProps fillProps { get; set; } = new FillProps(Color.Empty);
        
        public ItemType itemType { get; set; } = ItemType.None;
        public ItemFactory(ItemStore store)
        {
            items = store;
        }
        public void CreateItem(int x, int y)
        {
            Frame frame;    
            PropSet properties;

            switch (itemType)
            {
                case ItemType.Line:
                    frame = new Frame(x, y, x + 50, y + 50); // ИЗМЕНИТЬ
                    properties = new PropSet();
                    properties.Add(lineProps);
                    //properties.Apply();
                    items.Add(new Line(frame, properties));

                    break;
                case ItemType.Rect:
                    break;
                default:
                    break;
            }
        }
        public void ApplyProperties(ILineProperties lineProps, IFillProperties fillProps)
        {
            this.lineProps.Width = lineProps.Width;
            this.lineProps.Color = lineProps.Color;

            this.fillProps.Color = fillProps.Color;
        }
    }
    internal enum ItemType
    {
        None, Line, Rect
    }
}
