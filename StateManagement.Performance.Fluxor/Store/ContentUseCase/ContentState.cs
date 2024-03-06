using Fluxor;
using StateManagement.Performance.Models;

namespace StateManagement.Performance.Fluxor.Store.ContentUseCase;

[FeatureState(CreateInitialStateMethodName = nameof(CreateInitialState))]
public record ContentState(IEnumerable<BodyModel> Bodies)
{
    public static ContentState CreateInitialState() => new(new List<BodyModel>());
}
