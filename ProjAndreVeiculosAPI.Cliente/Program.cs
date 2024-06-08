using Microsoft.EntityFrameworkCore;
using ProjAndreVeiculosAPICliente.Controllers;
using ProjAndreVeiculosAPICliente.Data;
using ProjAndreVeiculosAPIEndereco.Controllers;
using ProjAndreVeiculosAPIEndereco.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjAndreVeiculosAPIClienteContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPIClienteContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPIClienteContext' not found.")));

builder.Services.AddDbContext<ProjAndreVeiculosAPIEnderecoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPIEnderecoContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPIEnderecoContext' not found.")));

// Registro dos contextos de banco de dados usando a mesma string de conexão
//var connectionString = builder.Configuration.GetConnectionString("ProjAndreVeiculosAPIClienteContext");

//builder.Services.AddDbContext<ProjAndreVeiculosAPIClienteContext>(options =>
//    options.UseSqlServer(connectionString));

//builder.Services.AddDbContext<ProjAndreVeiculosAPIEnderecoContext>(options =>
//    options.UseSqlServer(connectionString));



// Adicionar controladores ao contêiner de dependências
builder.Services.AddScoped<EnderecosController>();
builder.Services.AddScoped<ClientesController>();

// Adicionar serviços aos controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
