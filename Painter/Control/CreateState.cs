namespace Painter
{
    class CreateState : State
    {
        public CreateState(IModel model, IEventHandler eventHandler) : base(model, eventHandler)
        {
            Model = model;
            EventHandler = eventHandler;
            StateType = StateType.CreateState;
        }

        public override IModel Model { get;}

        public override IEventHandler EventHandler { get; }

        public override void LeftMouseDown(int x, int y)
        {
            Model.Create(x, y);
            EventHandler.ActiveState = EventHandler.States[StateType.GrabState]; // Оно так должно быть ???
        }

        public override void LeftMouseUp(int x, int y)
        {
            // ???
        }

        public override void MouseMove(int x, int y)
        {
            // ??? Что тут может быть ???
        }
    }
}
