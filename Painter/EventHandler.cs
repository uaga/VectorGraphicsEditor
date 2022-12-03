using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    interface IEventHandler
    {
        void LeftMouseUp(int x, int y);
        void LeftMouseDown(int x, int y);
    }
    internal class EventHandler : IEventHandler
    {
        IModel model;
        public EventHandler(IModel model)
        {
            this.model = model;
        }
        public void LeftMouseDown(int x, int y)
        {
            
        }

        public void LeftMouseUp(int x, int y)
        {
            model.Create(x, y);
        }
    }
}
