using System.Drawing;

namespace Painter
{
    //interface IGraphics
    //{
    //    void SetPort(int width, int height, Graphics graphics);
    //    void Repaint();
    //}
    interface IModel
    {
        ItemType CreatingItemType { get; set; }
        GraphicsProperties ItemProperties { get;}
        SelectionManeger SelectionManeger { get;}
        //IGraphics Graphics { get;}
        void Create(int x, int y);
        void Repeint();
    }
    internal class Model : IModel
    {
        readonly ItemFactory factory;
        readonly Scene scene;
        public SelectionManeger SelectionManeger { get; }
        DrawSystem DrawSystem;
        public Model(Graphics graphics)
        {
            ItemStore store = new ItemStore();
            SelectionManeger= new SelectionManeger(store);
            factory = new ItemFactory(store, SelectionManeger);
            ItemProperties = new GraphicsProperties(factory);
            DrawSystem = new DrawSystem(graphics);
            scene = new Scene(DrawSystem, store);
        }

        public ItemType CreatingItemType { get; set; }
        public GraphicsProperties ItemProperties { get; set; }
        //IGraphics Graphics { get;}

        public void Create(int x, int y)
        {
            factory.ItemType = CreatingItemType;
            //factory.CreateItem(x, y);
            factory.CreateAndGrab(x, y);
            Repeint();
        }

        public void Repeint()
        {
            scene.Repaint();
            SelectionManeger.Repaint(DrawSystem);
        }
    }
}
