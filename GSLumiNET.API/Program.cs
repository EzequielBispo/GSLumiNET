using GSLumiNET.Application.Services;
using GSLumiNET.Domain.Interfaces;
using GSLumiNET.Infrastructure.Repositories;
using GSLumiNET.Infrastructure.AppData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.
builder.Services.AddControllers();

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar o DbContext
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar Reposit�rios e Servi�os
builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();
builder.Services.AddScoped<IRegistroService, RegistroService>();

var app = builder.Build();

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
