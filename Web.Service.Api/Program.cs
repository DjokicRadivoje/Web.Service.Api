using Web.Service.BusinessLogic;
using Web.Service.IBusinessLogic;
using Web.Service.Services;
using Web.Service.Services.Interfaces;
using Serilog;
using Web.Service.Mapper;

var builder = WebApplication.CreateBuilder(args);


// Konfigurisemo Serilog za logovanje u fajl
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Log u fajl, kreira novi fajl svaki dan
    .CreateLogger();

builder.Host.UseSerilog(); // Menjamo podrazumevani logger sa Serilogom (da bi logove cuvali u fajlu).

//Dodajemo automapper
builder.Services.AddAutoMapper(typeof(DefaultProfile));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductBusinessLogic, ProductBusinessLogic>();

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
