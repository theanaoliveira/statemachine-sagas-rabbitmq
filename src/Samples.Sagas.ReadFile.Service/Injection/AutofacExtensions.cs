using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Sample.Sagas.Infrastructure.Modules;
using Samples.Sagas.ReadFile.Service.Modules;

namespace Samples.Sagas.ReadFile.Service.Injection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder, IServiceCollection services)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ReadFileModule>();

            builder.Populate(services);

            return builder;
        }
    }
}
