using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orchestrator.Injection;
using Orchestrator.UseCases;
using Serilog;

static IHost AppStartup()
{
    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger();

    var host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) => services.ConfigureQueue())
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(container => container.ResgiterExtensions())
        .UseSerilog()
        .Build();

    return host;
}

using IHost host = AppStartup();

var useCase = host.Services.GetService<IGetTransferFilesUseCase>();

await useCase.Execute();

await host.RunAsync();
