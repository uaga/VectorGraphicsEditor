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
            if (EventHandler.Model.SelectionManeger.TryGrab(x, y))
            {
                return;
            }
            else
            {
                //EventHandler.Model.SelectionManeger.SkipActiveSelection();
            }
            EventHandler.Model.Repeint();
        }

        public override void LeftMouseUp(int x, int y)
        {
            EventHandler.Model.SelectionManeger.Release();
            //EventHandler.ActiveState = EventHandler.States[StateType.CreateState];
        }

        public override void MouseMove(int x, int y)
        {
            EventHandler.Model.SelectionManeger.TryDrag(x, y);
            Model.Repeint();
        }

    }
}
