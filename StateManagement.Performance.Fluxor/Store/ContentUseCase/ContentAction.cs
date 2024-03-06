using StateManagement.Performance.Models;

namespace StateManagement.Performance.Fluxor.Store.ContentUseCase;
public class ContentAction
{
    public record SetBodiesAction(IEnumerable<BodyModel> Bodies) : IAction;

    public static SetBodiesAction SetBodies(IEnumerable<BodyModel> bodies) => new(bodies);
}
