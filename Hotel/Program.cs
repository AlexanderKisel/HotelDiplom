using Hotel.Api.Infrastructures;
using Hotel.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.GetAuthentication();

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

    app.UseExceptionHandler("/Transition/Error");
    //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Transition}/{action=HomePage}/{id?}");

app.Run();
