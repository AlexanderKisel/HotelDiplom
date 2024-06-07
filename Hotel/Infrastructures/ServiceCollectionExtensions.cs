using Hotel.Common;
using Hotel.Context;
using Hotel.Infrastructures.Validator;
using Hotel.Infrastructures;
using Hotel.Repositories;
using Hotel.Services;
using Hotel.Shared;
using Hotel.Common.Entity.InterfaceDB;

namespace Hotel.Api.Infrastructures
{
    static internal class ServiceCollectionExtensions
    {
        public static void AddDependencies(this IServiceCollection service)
        {

            service.AddTransient<IDateTimeProvider, DateTimeProvider>();
            service.AddTransient<IDbWriteContext, DbWriterContext>();
            service.AddTransient<IApiValidatorService, ApiValidatorService>();

            service.RegisterAutoMapperProfile<ApiAutoMapperProfile>();
            service.RegisterModule<ServiceModule>();
            service.RegisterModule<ContextModule>();
            service.RegisterModule<RepositoriyModule>();

            service.RegisterAutoMapper();
        }
    }
}
