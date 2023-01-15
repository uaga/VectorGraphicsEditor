using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Control.States
{
    internal class MultiSelection : State
    {
        public MultiSelection(IModel model, IEventHandler eventHandler) : base(model, eventHandler)
        {
            EventHandler = eventHandler;
            StateType = StateType.MultiSelection;
        }

        public override IEventHandler EventHandler { get; }

        public override void AltAndMouseDown(int x, int y)
        {
            //if (EventHandler.Model.SelectionManeger.)
            //{

            //}
        }

        public override void CtrlAndMouseDown(int x, int y)
        {
            if (EventHandler.Model.SelectionManeger.TryGrab(x,y))
            {
                EventHandler.Model.Repeint();
            }
        }

        public override void Delite()
        {
            
        }

        public override void Escape()
        {
            EventHandler.Model.SelectionManeger.SkipAll();
        }

        public override void Group()
        {
            if (EventHandler.Model.SelectionManeger.TryGroup())
            {
                EventHandler.ActiveState = EventHandler.States[StateType.SingleSelection];
                EventHandler.Model.Repeint();
            }
        }

        public override void LeftMouseDown(int x, int y)
        {
            
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
