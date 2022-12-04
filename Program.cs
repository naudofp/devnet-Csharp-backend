using Microsoft.EntityFrameworkCore;
using devnet_Csharp_backend.api.Services.developer;
using devnet_Csharp_backend.api.Data;
using devnet_Csharp_backend.api.Services.User;
using devnet_Csharp_backend.api.Services.user;
using devnet_Csharp_backend.api.Services.course;
using devnet_Csharp_backend.api.Services.security;

var builder = WebApplication.CreateBuilder(args);

var connectionStringMySql = builder.Configuration.GetConnectionString("ConnectionMysql");
builder.Services.AddDbContext<DevnetDBContext>(option => option.UseMySql(connectionStringMySql, ServerVersion.Parse("8.0.31")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DeveloperService, DeveloperServiceImpl>();
builder.Services.AddScoped<UserService, UserServiceImpl>();
builder.Services.AddScoped<CourseService, CourseServiceImpl>();
builder.Services.AddScoped<SecurityService, SecurityServiceImpl>();


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
