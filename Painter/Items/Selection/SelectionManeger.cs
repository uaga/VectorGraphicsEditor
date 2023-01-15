using System;
using System.Collections.Generic;

namespace Painter
{
    internal class SelectionManeger : ISelection
    {
        ItemStore Items { get; }
        readonly SelectionStore selections;
        public ItemFactory Factory { get; set; }
        public SelectionManeger(ItemStore items)
        {
            Items = items;
            selections = new SelectionStore();
        }

        public void Release()
        {
            //selections.Release();
            selections.Remove(selections.ActiveSelection);
            selections.ActiveSelection = null;
        }

        public void SkipAll()
        {
            selections.SkipAll();
        }

        public void SkipActiveSelection()
        {
            selections.ActiveSelection = null;
            selections.Clear();
        }

        public bool TryDrag(int x, int y)
        {
            if (selections.ActiveSelection == null) { return false; }
            return selections.ActiveSelection.TryDragTo(x, y);
        }

        public bool TryGrab(int x, int y)
        {
            if (TrySelect(x, y))
            {
                return selections.ActiveSelection.TryGrab(x, y) > 0;
            }
            return false;
        }

        public bool TryGroup()
        {
            if (selections.Count > 1)
            {
                List<Item> items = new List<Item>();
                foreach (Selection selection in selections)
                {
                    items.Add(selection.GetItem);
                }
                selections.Clear();
                Factory.CreateAndGrab(items);

                

                return true;
            }
            return false;
        }
        //public bool TryGrabFrame(int x, int y)
        //{

        //}
        public bool TrySelect(int x, int y)
        {
            Item selectItem = Items.TryGrab(x, y);
            if (selectItem != null)
            {
                Selection newSelection = selectItem.CreateSelection();
                selections.Add(newSelection);
                selections.ActiveSelection = newSelection;
                return true;
            }
            return false;
        }

        public bool TryUnGroup()
        {
            throw new NotImplementedException();
        }

        public void Repaint(DrawSystem drawSystem)
        {
            foreach (Selection selection in selections)
            {
                selection.Draw(drawSystem);
            }
        }
    }
}
