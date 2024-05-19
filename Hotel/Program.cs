using Hotel.Api.Infrastructures;
using Hotel.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.Filters.Add<HotelExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.GetSwaggerDocument();
builder.Services.AddDependencies();

var conSring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<HotelContext>(options => options.UseSqlServer(conSring),
    ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.GetSwaggerDocumentUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
