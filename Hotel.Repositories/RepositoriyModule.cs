using Hotel.Common;
using Hotel.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Repositories
{
    public class RepositoriyModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.AssemblyInterfaceAssignableTo<IRepositoryAnchor>(ServiceLifetime.Scoped);
        }
    }
}
