using System.Collections.Generic;

namespace Painter
{
    internal class StateStore : List<State>
    {
        public State this[StateType stateType]
        {
            get
            {
                //State retState;
                foreach (State state in this)
                {
                    if (state.StateType == stateType)
                    {
                        return state;
                    }
                }
                return null;
                //return retState;
            }
        }
        public StateStore(IModel model, IEventHandler eventHandler)
        {
            Add(new CreateState(model, eventHandler));
            Add(new GrabState(model, eventHandler));
        }
        //public State ActiveState()
        //{
        //    return 
        //}
    }
}
