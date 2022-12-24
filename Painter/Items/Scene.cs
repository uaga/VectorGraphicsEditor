

namespace Painter
{
    interface IGraphics
    {
        ItemType ItemType { get; }
        void SetPort(int weight, int height, DrawSystem drawSystem);
        void Repaint();
        void Creator();
        void CraeteAndCrab();
    }
    internal class Scene : IGraphics
    {
        ItemStore items;
        DrawSystem drawSystem;
        public Scene(DrawSystem drawSystem, ItemStore items)
        {
            this.drawSystem = drawSystem;
            this.items = items;
        }

        public ItemType ItemType { get; set; }

        public void CraeteAndCrab()
        {
            
        }

        public void Creator()
        {
            
        }

        public void Repaint()
        {
            drawSystem.Clear();
            foreach (Item item in items)
            {
                item.Draw(drawSystem);
            }
        }

        public void SetPort(int weight, int height, DrawSystem drawSystem)
        {
            
        }
    }
}
