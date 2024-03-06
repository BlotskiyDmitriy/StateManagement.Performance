using Fluxor;

namespace StateManagement.Performance.Fluxor.Store.ContentUseCase;
public class ContentReducers
{
    [ReducerMethod]
    public static ContentState Action(ContentState state, IAction action)
    {
        return action switch
        {
            ContentAction.SetBodiesAction a => state with { Bodies = a.Bodies },
            _ => state
        };
    }
}
