using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjAndreVeiculosAPIEndereco.Data;
using ProjAndreVeiculosAPIFuncionario.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjAndreVeiculosAPIFuncionarioContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPIFuncionarioContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPIFuncionarioContext' not found.")));

builder.Services.AddDbContext<ProjAndreVeiculosAPIEnderecoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPIEnderecoContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPIEnderecoContext' not found.")));

//builder.Services.AddDbContext<ProjAndreVeiculosAPIFuncionarioContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPIFuncionarioContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPIFuncionarioContext' not found.")));

// Add services to the container.

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
