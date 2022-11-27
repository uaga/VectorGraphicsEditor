

namespace Painter
{
    internal class Scene
    {
        ItemStore items;
        DrawSystem drawSystem;
        public Scene(DrawSystem drawSystem, ItemStore items)
        {
            this.drawSystem = drawSystem;
            this.items = items;
        }
        public void Repaint()
        {
            drawSystem.Clear();
            foreach (Item item in items)
            {
                item.Draw(drawSystem);
            }
        }
    }
}
