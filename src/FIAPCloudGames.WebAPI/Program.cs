using FIAPCloudGames.Application;
using FIAPCloudGames.Infrastructure;
using FIAPCloudGames.WebAPI;
using FIAPCloudGames.WebAPI.Middlewares;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) // Pega configuração do appsettings.json
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load));

// FIAP Cloud Games
builder.Services.AddApplication();
builder.Services.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerSetup();
}

app.UseReDoc(c =>
{
    c.DocumentTitle = "FIAPCloudGames - Project";
    c.SpecUrl = "/swagger/v1/swagger.json";

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();