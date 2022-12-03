using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    interface IController
    {
        IEventHandler eventHandler { get; }
        IModel model { get; }
        void SetTypeCreatingItem(ItemType type);
    }
    internal class Controller : IController
    {
        public IEventHandler eventHandler { get; }

        public IModel model { get; }

        //IEventHandler IController.EventHandler => throw new NotImplementedException();

        //IModel IController.model => throw new NotImplementedException();

        public Controller(IModel model)
        {
            this.model = model;
            eventHandler = new EventHandler(model);
        }
        public void SetTypeCreatingItem(ItemType type)
        {
            model.CreatingItemType = type;
        }
    }
}
