using ENTITIES;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});





builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var currentDirectory = Directory.GetCurrentDirectory();
builder.Host.UseContentRoot(currentDirectory);

Console.WriteLine("Current Directory");
Console.WriteLine(currentDirectory);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
Console.WriteLine(environment);

var contentRoot = builder.Environment.ContentRootPath;
Console.WriteLine($"Ruta raíz del contenido: {contentRoot}");


var mysql_connection = builder.Configuration.GetConnectionString("MySQL");
var connection2 = builder.Configuration.GetConnectionString("MySQL");

Console.WriteLine("Conexion a Mysql");
Console.WriteLine(mysql_connection);


builder.Services.AddDbContext<Context>(options => options.UseMySql(mysql_connection,ServerVersion.AutoDetect(mysql_connection)));
builder.Services.AddDbContext<WriteContext>(options => options.UseMySql(connection2, ServerVersion.AutoDetect(connection2)));


builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});


var app = builder.Build();
app.UseCors("AllowAll");
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
