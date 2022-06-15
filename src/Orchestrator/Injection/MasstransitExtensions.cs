using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orchestrator.Configuration;
using Orchestrator.Configuration.Persist;
using System.Reflection;

namespace Orchestrator.Injection
{
    public static class MasstransitExtensions
    {
        public static IServiceCollection ConfigureQueue(this IServiceCollection services)
        {
            string conn = Environment.GetEnvironmentVariable("DBCONN") ?? "";

            services.AddDbContext<MigrationStateDbContext>(builder =>{
                builder.UseNpgsql(conn, m => {
                    m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    m.MigrationsHistoryTable($"__{nameof(MigrationStateDbContext)}");
                });
            });

            services.AddMassTransit(x =>
            {
                x.AddSagaStateMachine<MigrationStateMachine, MigrationState>().EntityFrameworkRepository(r => {
                    r.ConcurrencyMode = ConcurrencyMode.Pessimistic;
                    r.LockStatementProvider = new PostgresLockStatementProvider();
                    r.ExistingDbContext< MigrationStateDbContext>();
                });

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
