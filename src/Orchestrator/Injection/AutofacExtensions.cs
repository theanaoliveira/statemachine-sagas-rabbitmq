using Autofac;
using Orchestrator.UseCases;
using Sample.Sagas.Infrastructure.Modules;
using Samples.Sagas.ReadFile.Service.Modules;

namespace Orchestrator.Injection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder ResgiterExtensions(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ReadFileModule>();
            builder.RegisterType<GetTransferFilesUseCase>().As<IGetTransferFilesUseCase>().AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

            return builder;
        }
    }
}
