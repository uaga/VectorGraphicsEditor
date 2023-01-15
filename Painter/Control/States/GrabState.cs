namespace Painter
{
    class GrabState : State
    {
        public GrabState(IModel model, IEventHandler eventHandler) : base(model, eventHandler)
        {
            EventHandler = eventHandler;
            StateType = StateType.GrabState;
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
                return;
            }
            else
            {
                EventHandler.Model.SelectionManeger.Release();
            }
            EventHandler.Model.Repeint();
        }

        public override void LeftMouseUp(int x, int y)
        {
            EventHandler.Model.SelectionManeger.Release();
            EventHandler.ActiveState = EventHandler.States[StateType.SingleSelection];
        }

        public override void MouseMove(int x, int y)
        {
            EventHandler.Model.SelectionManeger.TryDrag(x, y);
            EventHandler.Model.Repeint();
        }

        public override void UnGroup()
        {
            throw new System.NotImplementedException();
        }
    }
}
