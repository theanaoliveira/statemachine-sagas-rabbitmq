using Autofac;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Sample.Sagas.Application.Repositories.Services;
using Sample.Sagas.Infrastructure.Mapper;
using Sample.Sagas.Infrastructure.Services;

namespace Sample.Sagas.Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileConvert>().As<IFileConvert>().AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

            Mapper(builder);
        }

        private void Mapper(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(MapperProfile).Assembly).Where(t => (t.Namespace ?? string.Empty).Contains("Mapper") && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic).As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);

                cfg.AddExpressionMapping();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                    .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
