using BlazorState;
using StateManagement.Performance.Models;

namespace StateManagement.Performance.BlazorState.States;

public partial class ContentState : State<ContentState>
{
    public IEnumerable<BodyModel>? Bodies { get; private set; }

    public override void Initialize() => Bodies = new List<BodyModel>();

    public static class SetBody
    {
        public class Action : IAction
        {
            public IEnumerable<BodyModel>? Bodies { get; set; }
        }

        public class Handler : ActionHandler<Action>
        {
            public Handler(IStore aStore) : base(aStore) { }

            ContentState CounterState => Store.GetState<ContentState>();

            public override Task Handle(Action aAction, CancellationToken aCancellationToken)
            {
                CounterState.Bodies = aAction.Bodies;
                return Task.CompletedTask;
            }
        }
    }
}
