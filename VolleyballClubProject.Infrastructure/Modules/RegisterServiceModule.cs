using Autofac;
using System.Reflection;
using VolleyballClub.Application.Mapping;
using VolleyballClubProject.Application.Interfaces;
using VolleyballClubProject.Infrastructure.UnitOfWorks;
using Module = Autofac.Module;

namespace VolleyballClubProject.Infrastructure.Modules
{
    public class RegisterServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var infrastructureAssembly = Assembly.GetExecutingAssembly();
            var apiAssembly = Assembly.GetAssembly(typeof(MyMapping));
            builder.RegisterAssemblyTypes(infrastructureAssembly, apiAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
