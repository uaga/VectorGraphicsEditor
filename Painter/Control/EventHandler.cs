using System;

namespace Painter
{
    interface IEventHandler
    {
        StateStore States { get; }
        State ActiveState { get; set; }
        IModel Model { get; }
        void LeftMouseUp(int x, int y);
        void LeftMouseDown(int x, int y);
        void MouseMove(int x, int y);
    }
    class EventHandler : IEventHandler
    {
        public State ActiveState { get; set; }
        public IModel Model { get; set; }
        public StateStore States { get; }
        public EventHandler(IModel model)
        {
            States = new StateStore(model, this);
            Model= model;
            ActiveState = States[StateType.CreateState];
            Console.Write("");
        }
        public void LeftMouseDown(int x, int y)
        {
            ActiveState.LeftMouseDown(x, y);
        }
        public void LeftMouseUp(int x, int y)
        {
            ActiveState.LeftMouseUp(x, y);
        }
        public void MouseMove(int x, int y)
        {
            ActiveState.MouseMove(x, y);
        }
    }
}
