using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal class SingleSelection : State
    {
        public SingleSelection(IModel model, IEventHandler eventHandler) : base(model, eventHandler)
        {
            EventHandler = eventHandler;
            StateType = StateType.SingleSelection;
        }

        public override IEventHandler EventHandler { get; }

        public override void AltAndMouseDown(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void CtrlAndMouseDown(int x, int y)
        {
            if (EventHandler.Model.SelectionManeger.TryGrab(x,y))
            {
                EventHandler.ActiveState = EventHandler.States[StateType.MultiSelection];
                EventHandler.Model.Repeint();
            }
        }

        public override void Delite()
        {
            
        }

        public override void Escape()
        {
            
        }

        public override void Group()
        {
            throw new NotImplementedException();
        }

        public override void LeftMouseDown(int x, int y)
        {
            if (EventHandler.Model.SelectionManeger.TryGrab(x,y))
            {
                EventHandler.ActiveState = EventHandler.States[StateType.GrabState];
            }
            else
            {
                EventHandler.Model.SelectionManeger.SkipAll();
                EventHandler.Model.Repeint();
                EventHandler.ActiveState = EventHandler.States[StateType.EmptyState];
            }
        }

        public override void LeftMouseUp(int x, int y)
        {
            
        }

        public override void MouseMove(int x, int y)
        {
            
        }

        public override void UnGroup()
        {
            throw new NotImplementedException();
        }
    }
}
