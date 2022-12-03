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
        IGraphicsProperties ItemProperties { get;}
        //IGraphics Graphics { get;}
        void Create(int x, int y);
        void Repeint();
    }
    internal class Model : IModel
    {
        ItemFactory factory;
        Scene scene;
        
        public Model(Graphics graphics)
        {
            ItemStore store = new ItemStore();
            factory = new ItemFactory(store);
            ItemProperties = new GraphicsProperties(factory);

            scene = new Scene(new DrawSystem(graphics), store);
        }

        public ItemType CreatingItemType { get; set; }
        public IGraphicsProperties ItemProperties { get;}
        //IGraphics Graphics { get;}

        public void Create(int x, int y)
        {
            factory.itemType = CreatingItemType;
            factory.CreateItem(x, y);
            Repeint();
        }

        public void Repeint()
        {
            scene.Repaint();
        }
    }
}
