using PrimeraAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using PrimeraAPI.Core;
using PrimeraAPI.Core.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//obtengo la cadena de conexi�n
var conString = builder.Configuration.GetConnectionString("DevConnection");

//agrego el dbContext
builder
    .Services
    .AddDbContext<ApiDbContext>
    (options => options.UseSqlServer(conString));

//agrego el servicio de jugador
builder.Services.AddScoped<IJugadorService, JugadorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
