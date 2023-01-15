namespace Painter
{
    abstract class State
    {
        public StateType StateType { get; set; }
        public abstract IEventHandler EventHandler { get; }
        public State(IModel model, IEventHandler eventHandler)
        {
        }
        public abstract void CtrlAndMouseDown(int x, int y);
        public abstract void AltAndMouseDown(int x, int y);
        public abstract void Delite();
        public abstract void Escape();
        public abstract void Group();
        public abstract void UnGroup();
        public abstract void LeftMouseDown(int x, int y);
        public abstract void LeftMouseUp(int x, int y);
        public abstract void MouseMove(int x, int y);
    }
}
