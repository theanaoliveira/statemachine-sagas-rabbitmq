using Autofac;
using Samples.Sagas.ReadFile.Service.UseCases.ReadFile;

namespace Samples.Sagas.ReadFile.Service.Modules
{
    public class ReadFileModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReadFileUseCase>().As<IReadFileUseCase>().AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();
        }
    }
}
