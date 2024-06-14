using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ProjAndreVeiculosAPICondutor.Controllers;
using ProjAndreVeiculosAPICondutor.Data;
using ProjAndreVeiculosAPIEndereco.Controllers;
using ProjAndreVeiculosAPIEndereco.Data;
using ProjAndreVeiculosAPIEndereco.Services;
using ProjAndreVeiculosAPIEndereco.Utilis;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados para ProjAndreVeiculosAPICondutorContext
builder.Services.AddDbContext<ProjAndreVeiculosAPICondutorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPICondutorContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPICondutorContext' not found."))
);

// Configuração do banco de dados para ProjAndreVeiculosAPIEnderecoContext
builder.Services.AddDbContext<ProjAndreVeiculosAPIEnderecoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPIEnderecoContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPIEnderecoContext' not found."))
);


// Adiciona controladores
builder.Services.AddScoped<EnderecosController>();
builder.Services.AddScoped<CondutoresController>();
builder.Services.AddScoped<CNHsController>();

builder.Services.AddControllers();

builder.Services.Configure<ProjMongoDBAPIDataBaseSettings>(
               builder.Configuration.GetSection(nameof(ProjMongoDBAPIDataBaseSettings)));

builder.Services.AddSingleton<IProjMongoDBAPIDataBaseSettings>(sp =>
    (IProjMongoDBAPIDataBaseSettings)sp.GetRequiredService<IOptions<ProjMongoDBAPIDataBaseSettings>>().Value);


builder.Services.AddSingleton<EnderecoService>();


// Adiciona suporte para Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
