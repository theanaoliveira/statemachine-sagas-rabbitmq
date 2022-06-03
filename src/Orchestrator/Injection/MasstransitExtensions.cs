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
                x.AddSagaStateMachine<MigrationStateMachine, MigrationState>();
            });

            return services;
        }
    }
}
