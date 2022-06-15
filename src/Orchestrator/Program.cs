using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orchestrator.Configuration.Persist;
using Orchestrator.Injection;
using Orchestrator.UseCases;
using Sample.Sagas.Infrastructure.Modules;
using Samples.Sagas.ReadFile.Service.Modules;
using Serilog;

static IHost AppStartup()
{
    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger();

    var host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.ConfigureQueue();

        })
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(container =>
        {
            container.RegisterModule<InfrastructureModule>();
            container.RegisterModule<ReadFileModule>();

            container.RegisterType<GetTransferFilesUseCase>().As<IGetTransferFilesUseCase>().AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

        }
        )
        .UseSerilog()
        .Build();
    return host;
}

using IHost host = AppStartup();

await using var scope = host.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<MigrationStateDbContext>();
await db.Database.MigrateAsync();

var useCase = host.Services.GetService<IGetTransferFilesUseCase>();

await useCase.Execute();

await host.RunAsync();
