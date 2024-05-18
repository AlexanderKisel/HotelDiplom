using Microsoft.OpenApi.Models;

namespace Hotel.Api.Infrastructures
{
    static internal class DocumentExtensions
    {
        public static void GetSwaggerDocument(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Booking", new OpenApiInfo {Title = "Сущность бронирования", Version = "v1"});
                c.SwaggerDoc("Room", new OpenApiInfo {Title = "Сущность комнаты(номера)", Version = "v1"});
                c.SwaggerDoc("Worker", new OpenApiInfo {Title = "Сущность сотрудники", Version = "v1"});
                c.SwaggerDoc("Person", new OpenApiInfo {Title = "Сущность персоны(клиенты)", Version = "v1"});
                c.SwaggerDoc("Menu", new OpenApiInfo {Title = "Сущность меню", Version = "v1"});

                var filePath = Path.Combine(AppContext.BaseDirectory, "Hotel.Api.xml");
                c.IncludeXmlComments(filePath);
            });
        }
        public static void GetSwaggerDocumentUI(this WebApplication app)
        {
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("Booking/swagger.json", "Бронирования");
                x.SwaggerEndpoint("Room/swagger.json", "Комнаты(номера)");
                x.SwaggerEndpoint("Worker/swagger.json", "Работники");
                x.SwaggerEndpoint("Person/swagger.json", "Персоны(клиенты)");
                x.SwaggerEndpoint("Menu/swagger.json", "Меню");
            });
        }
    }
}
