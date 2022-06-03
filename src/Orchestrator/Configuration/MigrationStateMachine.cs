using MassTransit;
using Orchestrator.Contracts;

namespace Orchestrator.Configuration
{
    public class MigrationStateMachine : MassTransitStateMachine<MigrationState>
    {
        public MigrationStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => ReadFileSubmitted, context => context.CorrelateById(i => i.Message.FileId));

            Initially(
                When(ReadFileSubmitted).Then(context =>
                {
                    context.Saga.CorrelationId = context.Message.FileId;
                })
                .SendAsync(new Uri("queue:read-file"), context => context.Init<Samples.Sagas.ReadFile.Service.Masstransit.Contracts.File>(new
                {
                    FileId = context.Message.FileId,
                    FilePath = context.Message.File
                }))
                .Finalize());
        }

        public State ReadFileRequested { get; set; }

        public Event<ReadFileSubmitted> ReadFileSubmitted { get; set; }
    }
}
