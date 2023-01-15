using Painter.Properties;
using System.Collections.Generic;
using System.Drawing;

namespace Painter
{
    class ItemStore : List<Item>
    {
        public Item TryGrab(int x, int y)
        {
            foreach (Item item in this)
            {
                if (item.TryGrab(x,y))
                {
                    return item;
                }
            }
            return null;
        }
    }
    class ItemFactory : IFactory
    {
        ItemStore items;
        LineProps lineProps { get; set; } = new LineProps(Color.Black, 1);
        FillProps fillProps { get; set; } = new FillProps(Color.Empty);
        SelectionManeger SelectionManeger { get; set; }
        public ItemType ItemType { get; set; } = ItemType.None;
        public ItemFactory(ItemStore store, SelectionManeger selectionManeger)
        {
            items = store;
            SelectionManeger= selectionManeger;
        }
        public Item CreateItem(int x, int y)
        {
            Frame frame;    
            PropSet properties;

            switch (ItemType)
            {
                case ItemType.Line:
                    frame = new Frame(x, y, x + 150, y + 150);
                    properties = new PropSet
                    {
                        lineProps.Copy()
                    };
                    return new Line(frame, properties);
                case ItemType.Rect:
                    frame = new Frame(x, y, x + 150, y + 150);
                    properties = new PropSet
                    {
                        lineProps.Copy(),
                        fillProps.Copy()
                    };
                    return new Rect(frame, properties);
                default:
                    return null;
            }
        }
        public void ApplyProperties(ILineProperties lineProps, IFillProperties fillProps)
        {
            this.lineProps.Width = lineProps.Width;
            this.lineProps.Color = lineProps.Color;


            this.fillProps.Color = (fillProps == null ? Color.Empty : fillProps.Color);
        }
        public void CreateAndGrab(int x, int y)
        {
            Item item = CreateItem(x, y);
            items.Add(item);
            SelectionManeger.TrySelect(x, y);
        }
        public void CreateAndGrab(List<Item> items)
        {
            Item item = CreateItem(items);
            items.Add(item);
            SelectionManeger.TrySelect(items[0].frame.x1, items[0].frame.y1);
        }
        public Item CreateItem(List<Item> items)
        {
            Item group = new Group(items);
            this.items.Clear();
            this.items.Add(group);
            return group;
        }
    }
    internal enum ItemType
    {
        None, Line, Rect, 
    }
}
