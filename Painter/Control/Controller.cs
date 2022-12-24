

namespace Painter
{
    interface IController
    {
        IModel Model { get; }
        IEventHandler EventHandler { get; }
        void SetTypeCreatingItem(ItemType type);
    }
    internal class Controller : IController
    {
        public IEventHandler EventHandler { get; set; }
        public IModel Model { get; }
        public Controller(IModel model)
        {
            Model = model;
            EventHandler = new EventHandler(model);
        }
        public void SetTypeCreatingItem(ItemType type)
        {
            Model.CreatingItemType = type;
        }
    }
}
