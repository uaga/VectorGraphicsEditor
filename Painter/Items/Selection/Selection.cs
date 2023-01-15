using System.Collections.Generic;
using System.Drawing;

namespace Painter
{
    enum ChangeType { Move, Resize, }
    abstract class Selection
    {
        readonly protected int size_marker = 5;
        readonly protected int upLeftMark = 0;
        readonly protected int downRightMark = 1;
        protected ChangeType ChangeType { get; set; }
        public Item GetItem { get => Item; }
        protected int ActiveMark = -1;
        protected Point grabPoint= new Point(-1, -1);
        protected Item Item;
        public List<Rectangle> Markers { get; } = new List<Rectangle>();
        /// <summary>
        /// Определяет тип изменения объекта Перемещение/Мастабирование
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>1 - Мастибирование, 2 - Перемещение, 0 - Ничего</returns>
        public abstract int TryGrab(int x, int y);
        public bool TryDragTo(int x, int y)
        {
            switch (ChangeType)
            {
                case ChangeType.Move:
                    return Move(x, y);
                case ChangeType.Resize:
                    return Resize(x, y);
                default:
                    return false;
            }
        }
        public bool TryDragTo(int ActiveMark, int x, int y)
        {
            this.ActiveMark = ActiveMark;
            ChangeType = ChangeType.Resize;
            return TryDragTo(x, y);
        }
        public abstract bool Move(int x, int y);
        public abstract bool Resize(int x, int y);
        //public void ReleaseGrab()
        //{
        //    ActiveMark= Rectangle.Empty;
        //}
        public void Draw(DrawSystem drawSystem)
        {
            drawSystem.DrawSelection(Markers);
            drawSystem.DrawFrame(Item.frame);
        }
        /// <summary>
        /// Возвращает <b>try</b> если точка на линии фрейма с погрешность size_marker
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool TryGrabFromFrame(int x, int y)
        {
            if (Item.frame.x1 - size_marker < x & Item.frame.x1 + size_marker > x & Item.frame.y1 - size_marker < y & Item.frame.y2 + size_marker > y) { return true; }
            else if (Item.frame.x2 - size_marker < x & Item.frame.x2 + size_marker > x & Item.frame.y1 - size_marker < y & Item.frame.y2 + size_marker > y) { return true; }
            else if (Item.frame.y1 - size_marker < y & Item.frame.y1 + size_marker > y & Item.frame.x1 - size_marker < x & Item.frame.x2 + size_marker > x) { return true; }
            else if (Item.frame.y2 - size_marker < y & Item.frame.y2 + size_marker > y & Item.frame.x1 - size_marker < x & Item.frame.x2 + size_marker > x) { return true; }
            else { return false; }
        }
        public virtual void UpdateMarkers()
        {
            Markers.Clear();
            Markers.Add(new Rectangle(Item.frame.x1 - size_marker, Item.frame.y1 - size_marker, size_marker * 2, size_marker * 2)); // 0 - up left
            Markers.Add(new Rectangle(Item.frame.x2 - size_marker, Item.frame.y2 - size_marker, size_marker * 2, size_marker * 2)); // 1 - down right
            Markers.Add(new Rectangle(Item.frame.x1 - size_marker, Item.frame.y2 - size_marker, size_marker * 2, size_marker * 2)); // 2 - down left
            Markers.Add(new Rectangle(Item.frame.x2 - size_marker, Item.frame.y1 - size_marker, size_marker * 2, size_marker * 2)); // 3 - up right
        }
        public void MoveMarkers(int x, int y)
        {
            switch (ActiveMark)
            {
                case 2:
                    Markers[ActiveMark] = new Rectangle(x - size_marker, y - size_marker, size_marker * 2, size_marker * 2);
                    Markers[0] = new Rectangle(x - size_marker, Markers[0].Y, size_marker * 2, size_marker * 2);
                    Markers[1] = new Rectangle(Markers[1].X, y - size_marker, size_marker * 2, size_marker * 2);
                    break;
                case 3:
                    Markers[ActiveMark] = new Rectangle(x - size_marker, y - size_marker, size_marker * 2, size_marker * 2);
                    Markers[1] = new Rectangle(x - size_marker, Markers[1].Y, size_marker * 2, size_marker * 2);
                    Markers[0] = new Rectangle(Markers[0].X, y - size_marker, size_marker * 2, size_marker * 2);
                    break;
                default:
                    Markers[ActiveMark] = new Rectangle(x - size_marker, y - size_marker, size_marker * 2, size_marker * 2);
                    break;
            }
        }
        public void UpdateFrame()
        {
            Item.frame = new Frame(Markers[upLeftMark].X + size_marker, Markers[upLeftMark].Y + size_marker, Markers[downRightMark].X + size_marker, Markers[downRightMark].Y + size_marker);
        }
    }
}
