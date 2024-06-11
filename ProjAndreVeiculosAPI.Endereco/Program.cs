using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjAndreVeiculosAPIEndereco.Data;
using ProjAndreVeiculosAPIEndereco.Services;
using ProjAndreVeiculosAPIEndereco.Utilis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjAndreVeiculosAPIEnderecoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosAPIEnderecoContext")
    ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosAPIEnderecoContext' not found.")));



// Adicionar controladores ao contêiner de dependências
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ProjMongoDBAPIDataBaseSettings>(
               builder.Configuration.GetSection(nameof(ProjMongoDBAPIDataBaseSettings)));

builder.Services.AddSingleton<IProjMongoDBAPIDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ProjMongoDBAPIDataBaseSettings>>().Value);

builder.Services.AddSingleton<EnderecoService>();

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