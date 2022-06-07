using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orchestrator.Injection;
using Orchestrator.UseCases;

using IHost host = Host.CreateDefaultBuilder(args).Build();
var services = new ServiceCollection();

services.ConfigureQueue();

var container = RegisterContainers(services);

var bus = container.Resolve<IBusControl>();

bus.Start();

Init(container);

await host.RunAsync();

#region Methods

static IContainer RegisterContainers(IServiceCollection services)
{
    var builder = new ContainerBuilder();

    builder.RegisterType<GetTransferFilesUseCase>().As<IGetTransferFilesUseCase>().AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();
    builder.Populate(services);

    return builder.Build();
}

static void Init(IContainer container)
{
    var useCase = container.Resolve<IGetTransferFilesUseCase>();

    useCase.Execute();
}

#endregion