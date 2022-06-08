using MassTransit;
using Orchestrator.Contracts;
using Samples.Sagas.ProcessLine.Service.Masstransit.Contracts;
using Samples.Sagas.ReadFile.Service.Masstransit.Contracts;

namespace Orchestrator.Configuration
{
    public class MigrationStateMachine : MassTransitStateMachine<MigrationState>
    {
        public MigrationStateMachine()
        {
            InstanceState(x => x.CurrentState, LineRequested);

            Event(() => ReadFileSubmitted, context => context.CorrelateById(i => i.Message.FileId));
            Event(() => LineSubmitted, context => context.CorrelateById(i => i.Message.FileId));

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
                .TransitionTo(LineRequested));

            During(LineRequested,
                When(LineSubmitted)
                .SendAsync(new Uri("queue:process-line"), context => context.Init<Line>(new
                {
                    FileId = context.Message.FileId,
                    LineId = context.Message.LineId
                })));
        }

        public State LineRequested { get; set; }

        public Event<ReadFileSubmitted> ReadFileSubmitted { get; set; }
        public Event<ILineSubmitted> LineSubmitted { get; set; }
    }
}
