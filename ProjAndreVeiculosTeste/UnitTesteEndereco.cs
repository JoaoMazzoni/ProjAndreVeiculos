using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using NuGet.ContentModel;
using ProjAndreVeiculosAPIEndereco.Controllers;
using ProjAndreVeiculosAPIEndereco.Data;

namespace ProjAndreVeiculosTeste
{
    public class UnitTesteEndereco
    {
        private DbContextOptions <ProjAndreVeiculosAPIEnderecoContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<ProjAndreVeiculosAPIEnderecoContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())     
                .Options;

            using (var contexto = new ProjAndreVeiculosAPIEnderecoContext(options))
            {
                contexto.Endereco.Add(new Endereco { Id = 1, Logradouro = "Rua 1", CEP = "12345678", Bairro = "Bairro 1", Complemento = "Complemento 1", Numero = 1, Uf = "SP", Cidade = "São Paulo" });
                contexto.Endereco.Add(new Endereco { Id = 2, Logradouro = "Rua 2", CEP = "87654321", Bairro = "Bairro 2", Complemento = "Complemento 2", Numero = 2, Uf = "RJ", Cidade = "Rio de Janeiro" });
                contexto.Endereco.Add(new Endereco { Id = 3, Logradouro = "Rua 3", CEP = "45678912", Bairro = "Bairro 3", Complemento = "Complemento 3", Numero = 3, Uf = "MG", Cidade = "Belo Horizonte" });
            }
        }
        [Fact]
        public void TesteGetAll()
        {
            InitializeDataBase();
            using (var contexto = new ProjAndreVeiculosAPIEnderecoContext(options))
            {
                EnderecosController controller = new EnderecosController(contexto);
                IEnumerable<Endereco> enderecos = controller.GetEndereco().Result.Value;
                Assert.Equal(3, enderecos.Count());
            }
        }
        [Fact]
        public void TesteGetById()
        {
            InitializeDataBase();
            using (var contexto = new ProjAndreVeiculosAPIEnderecoContext(options))
            {
                EnderecosController controller = new EnderecosController(contexto);
                Endereco endereco = controller.GetEndereco(1).Result.Value;
                Assert.Equal("Rua 1", endereco.Logradouro);
            }
        }

        [Fact]
        public void TesteGetByIdNotFound()
        {
            InitializeDataBase();
            using (var contexto = new ProjAndreVeiculosAPIEnderecoContext(options))
            {
                EnderecosController controller = new EnderecosController(contexto);
                ActionResult<Endereco> endereco = controller.GetEndereco(4).Result;
                Assert.IsType<NotFoundResult>(endereco.Result);
            }
        }

        [Fact]
        public void TestePost()
        {
            InitializeDataBase();
            using (var contexto = new ProjAndreVeiculosAPIEnderecoContext(options))
            {
                EnderecosController controller = new EnderecosController(contexto);
                Endereco endereco = new Endereco { CEP = "15997088", Complemento = "Complemento 4", Numero = 4 };
                controller.PostEndereco(endereco);
                Assert.True(contexto.Endereco.Any(e => e.Logradouro == "Avenida Minas Gerais"));
            }
        }

    }
}