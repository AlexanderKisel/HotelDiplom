using Hotel.Common;
using Hotel.Services.AutoMappers;
using Hotel.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Services
{
    public class ServiceModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IServiceAnchor>(ServiceLifetime.Scoped);
            service.RegisterAutoMapperProfile<ServiceProfile>();
        }
    }
}
