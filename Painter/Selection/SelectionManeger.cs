using System;

namespace Painter
{
    internal class SelectionManeger : ISelection
    {
        ItemStore Items { get; }
        readonly SelectionStore selections;
        public SelectionManeger(ItemStore items)
        {
            Items = items;
            selections = new SelectionStore();
        }

        public void Release()
        {
            selections.ActiveSelection = null;
            //selections.Release();
        }

        public void SkipAll()
        {
            //selections.Release();
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
                return selections.ActiveSelection.TryGrab(x, y);
            }
            return false;
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
                Selection newSelection = selectItem.CreateSelection();
                selections.Add(newSelection);
                selections.ActiveSelection = newSelection;
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
