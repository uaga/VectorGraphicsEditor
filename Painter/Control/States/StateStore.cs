using Painter.Control.States;
using System.Collections.Generic;

namespace Painter
{
    internal class StateStore : List<State>
    {
        public State this[StateType stateType]
        {
            get
            {
                foreach (State state in this)
                {
                    if (state.StateType == stateType)
                    {
                        return state;
                    }
                }
                return null;
            }
        }
        public StateStore(IModel model, IEventHandler eventHandler)
        {
            Add(new CreateState(model, eventHandler));
            Add(new GrabState(model, eventHandler));
            Add(new SingleSelection(model, eventHandler));
            Add(new EmptyState(model, eventHandler));
            Add(new MultiSelection(model, eventHandler));
        }
    }
}
