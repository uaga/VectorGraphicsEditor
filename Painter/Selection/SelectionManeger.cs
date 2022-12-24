using System;

namespace Painter
{
    internal class SelectionManeger : ISelection
    {
        ItemStore Items { get; }
        SelectionStore selections;
        public SelectionManeger(ItemStore items)
        {
            Items = items;
            selections = new SelectionStore();
        }

        public void Release()
        {
            selections.Release();
        }

        public void SkipAll()
        {
            //selections.Release();
        }

        public bool TryDrag(int x, int y)
        {
            return true;
        }

        public bool TryGrab(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool TryGroup(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool TrySelect(int x, int y)
        {
            Item selectItem = Items.TryGrab(x, y);
            if (selectItem != null)
            {
                selections.Add(selectItem.CreateSelection());
                return true;
            }
            return false;
        }

        public bool TryUnGroup(int x, int y)
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
