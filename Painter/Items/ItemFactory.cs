﻿using Painter.Properties;
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
                    frame = new Frame(x, y, x + 150, y + 150); // ИЗМЕНИТЬ
                    properties = new PropSet
                    {
                        lineProps.Copy()
                    };
                    return new Line(frame, properties);

                    //items.Add(new Line(frame, properties));
                    //break;
                case ItemType.Rect:
                    frame = new Frame(x, y, x + 150, y + 150);
                    properties = new PropSet
                    {
                        lineProps.Copy(),
                        fillProps.Copy()
                    };
                    return new Rect(frame, properties);

                    //items.Add(new Rect(frame, properties));
                    //break;
                default:
                    return null;

                    //break;
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
    }
    internal enum ItemType
    {
        None, Line, Rect
    }
}
