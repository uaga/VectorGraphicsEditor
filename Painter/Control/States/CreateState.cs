namespace Painter
{
    class CreateState : State
    {
        public CreateState(IModel model, IEventHandler eventHandler) : base(model, eventHandler)
        {
            EventHandler = eventHandler;
            StateType = StateType.CreateState;
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
            EventHandler.Model.Create(x, y);
            EventHandler.ActiveState = EventHandler.States[StateType.GrabState];
        }

        public override void LeftMouseUp(int x, int y)
        {
            // ???
        }

        public override void MouseMove(int x, int y)
        {
            // ??? Что тут может быть ???
        }

        public override void UnGroup()
        {
            throw new System.NotImplementedException();
        }
    }
}
