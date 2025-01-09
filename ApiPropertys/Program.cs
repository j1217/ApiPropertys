using Microsoft.EntityFrameworkCore;
using WebApiPropertys.Domain.Interfaces;
using WebApiPropertys.Infrastructure.Data;
using WebApiPropertys.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
builder.Services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();


builder.Services.AddControllers();

// Agregar el contexto de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
