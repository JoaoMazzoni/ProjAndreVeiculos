using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjAndreVeiculosAPICondutor.Controllers;
using ProjAndreVeiculosAPICondutor.Data;
using ProjAndreVeiculosAPIEndereco.Controllers;
using ProjAndreVeiculosAPIEndereco.Data;
using ProjAndreVeiculosAPIEndereco.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjAndreVeiculosAPICondutorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPICondutorContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPICondutorContext' not found.")));

builder.Services.AddDbContext<ProjAndreVeiculosAPIEnderecoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPIEnderecoContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPIEnderecoContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();


// Adicionar controladores ao contêiner de dependências
builder.Services.AddScoped<EnderecosController>();
builder.Services.AddScoped<CondutoresController>();

builder.Services.AddControllers();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
