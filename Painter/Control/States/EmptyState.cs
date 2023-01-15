namespace Painter
{
    internal class EmptyState : State
    {
        public EmptyState(IModel model, IEventHandler eventHandler) : base(model, eventHandler)
        {
            EventHandler = eventHandler;
            StateType = StateType.EmptyState;
        }

        public override IEventHandler EventHandler { get; }

        public override void AltAndMouseDown(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public override void CtrlAndMouseDown(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public override void Delite()
        {
            throw new System.NotImplementedException();
        }

        public override void Escape()
        {
            throw new System.NotImplementedException();
        }

        public override void Group()
        {
            throw new System.NotImplementedException();
        }

        public override void LeftMouseDown(int x, int y)
        {
            if (EventHandler.Model.SelectionManeger.TryGrab(x, y))
            {
                EventHandler.ActiveState = EventHandler.States[StateType.GrabState];
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
            throw new System.NotImplementedException();
        }
    }
}
