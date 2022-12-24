namespace Painter
{
    class GrabState : State
    {
        public GrabState(IModel model, IEventHandler eventHandler) : base(model, eventHandler)
        {
            Model = model;
            EventHandler = eventHandler;
            StateType = StateType.GrabState;
        }

        public override IModel Model { get; }

        public override IEventHandler EventHandler { get; }

        public override void LeftMouseDown(int x, int y)
        {
            EventHandler.Model.SelectionManeger.TrySelect(x, y);
            EventHandler.Model.Repeint();
        }

        public override void LeftMouseUp(int x, int y)
        {

        }

        public override void MouseMove(int x, int y)
        {

            Model.Repeint();
        }
    }
}
