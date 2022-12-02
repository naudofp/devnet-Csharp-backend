using Microsoft.EntityFrameworkCore;
using devnet_Csharp_backend.api.Services.developer;
using devnet_Csharp_backend.api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringMySql = builder.Configuration.GetConnectionString("ConnectionMysql");
builder.Services.AddDbContext<DevnetDBContext>(option => option.UseMySql(connectionStringMySql, ServerVersion.Parse("8.0.31")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DeveloperService, DeveloperServiceImpl>();


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
