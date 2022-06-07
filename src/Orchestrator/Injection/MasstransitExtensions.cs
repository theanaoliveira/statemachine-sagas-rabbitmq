using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Orchestrator.Configuration;

namespace Orchestrator.Injection
{
    public static class MasstransitExtensions
    {
        public static IServiceCollection ConfigureQueue(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddSagaStateMachine<MigrationStateMachine, MigrationState>().InMemoryRepository();

                x.UsingRabbitMq((context, configurator) =>
                {
                    x.SetKebabCaseEndpointNameFormatter();

                    configurator.ReceiveEndpoint("migration-saga", e =>
                    {
                        e.UseMessageRetry(r => r.Immediate(50));
                        e.UseInMemoryOutbox();
                        e.StateMachineSaga<MigrationState>(context);
                    });
                });
            });

            return services;
        }
    }
}
