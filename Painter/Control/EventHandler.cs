using System;

namespace Painter
{
    interface IEventHandler
    {
        StateStore States { get; }
        State ActiveState { get; set; }
        IModel Model { get; }
        void CtrlAndMouseDown(int x, int y);
        void AltAndMouseDown(int x, int y);
        void Delite();
        void Escape();
        void LeftMouseUp(int x, int y);
        void LeftMouseDown(int x, int y);
        void MouseMove(int x, int y);
        void Group();
        void UnGroup();
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
            // Если будет скучно прикрутить измение курсора при наведении на части Item (Resize / Move)

            //if (Model.SelectionManeger.)
            //{

            //}
            ActiveState.MouseMove(x, y);
        }

        public void CtrlAndMouseDown(int x, int y)
        {
            ActiveState.CtrlAndMouseDown(x, y);
        }

        public void AltAndMouseDown(int x, int y)
        {
            ActiveState.AltAndMouseDown(x, y);
        }

        public void Delite()
        {
            ActiveState.Delite();
        }

        public void Escape()
        {
            ActiveState.Escape();
        }

        public void Group()
        {
            ActiveState.Group();
        }

        public void UnGroup()
        {
            ActiveState.UnGroup();
        }
    }
}
