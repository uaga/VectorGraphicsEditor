namespace Painter
{
    abstract class State
    {
        public StateType StateType { get; set; }
        public abstract IEventHandler EventHandler { get; }
        public abstract IModel Model { get; }
        public State(IModel model, IEventHandler eventHandler)
        {

            //EventHandler = eventHandler;
            //Model = model;
        }
        public abstract void LeftMouseDown(int x, int y);
        public abstract void LeftMouseUp(int x, int y);
        public abstract void MouseMove(int x, int y);
    }
}
