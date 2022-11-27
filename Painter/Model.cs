using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    interface IModel
    {
        ItemType ItemType { get; set; }
        IGraphicsProperties ItemProperties { get; set; }
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

            // Временное решение
            ItemProperties.lineProperties = new LineProps(Color.Black, 1);
            ItemProperties.fillProperties = new FillProps(Color.Empty);
            ItemProperties.ApplyProperties();

            scene = new Scene(new DrawSystem(graphics), store);
        }

        public ItemType ItemType { get; set; }
        public IGraphicsProperties ItemProperties { get; set; }

        public void Create(int x, int y)
        {
            factory.itemType = ItemType;
            factory.CreateItem(x, y);
            Repeint();
        }

        public void Repeint()
        {
            scene.Repaint();
        }
    }
}
