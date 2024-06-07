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
                c.SwaggerDoc("Autorization", new OpenApiInfo {Title = "Сущность Авторизация", Version = "v1"});

                var filePath = Path.Combine(AppContext.BaseDirectory, "Hotel.Api.xml");
                c.IncludeXmlComments(filePath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Пожалуйста введите JWT-токен",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
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
                x.SwaggerEndpoint("Autorization/swagger.json", "Авторизация");
            });
        }
    }
}
