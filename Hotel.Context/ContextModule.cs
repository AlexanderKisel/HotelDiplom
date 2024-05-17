using Hotel.Common;
using Hotel.Common.Entity.InterfaceDB;
using Hotel.Context.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Hotel.Context
{
    public class ContextModule : Module
    {
        public override void CreateModule(IServiceCollection service)
        {
            service.TryAddScoped<IHotelContext>(provider => provider.GetRequiredService<HotelContext>());
            service.TryAddScoped<IDbRead>(provider => provider.GetRequiredService<HotelContext>());
            service.TryAddScoped<IDbWrite>(provider => provider.GetRequiredService<HotelContext>());
            service.TryAddScoped<IUnitOfWork>(provider => provider.GetRequiredService<HotelContext>());
        }
    }
}
