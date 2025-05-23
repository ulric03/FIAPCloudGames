using FIAPCloudGames.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

// FIAP Cloud Games
builder.Services.AddPresentation();

var app = builder.Build();

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
