using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosAPICarro.Controllers;
using ProjAndreVeiculosAPICarro.Data;
using ProjAndreVeiculosAPIEndereco.Controllers;
using ProjAndreVeiculosAPIEndereco.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAndreVeiculosTeste
{
    public class UnitTesteCarro
    {

        private DbContextOptions<ProjAndreVeiculosAPICarroContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<ProjAndreVeiculosAPICarroContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var contexto = new ProjAndreVeiculosAPICarroContext(options))
            {

                contexto.Carro.Add(new Carro { Placa = "ABC0001", Nome = "Ford", AnoFabricacao = 2020, AnoModelo = 2021, Cor = "Prata", Vendido = false });
                contexto.Carro.Add(new Carro { Placa = "ABC0002", Nome = "Mercedes", AnoFabricacao = 2022, AnoModelo = 2023, Cor = "Preto", Vendido = false });
                contexto.Carro.Add(new Carro { Placa = "ABC0003", Nome = "Chevrolet", AnoFabricacao = 2021, AnoModelo = 2022, Cor = "Branco", Vendido = true });
                contexto.SaveChanges();
            }
        }
        [Fact]
        public void TesteGetAll()
        {
            InitializeDataBase();
            using (var contexto = new ProjAndreVeiculosAPICarroContext(options))
            {
                CarrosController controller = new CarrosController(contexto);
                IEnumerable<Carro> carros = controller.GetCarro().Result.Value;
                Assert.Equal(3, carros.Count());
            }
        }
        [Fact]
        public void TesteGetById()
        {
            InitializeDataBase();
            using (var contexto = new ProjAndreVeiculosAPICarroContext(options))
            {
                CarrosController controller = new CarrosController(contexto);
                Carro carro = controller.GetCarro("ABC0002").Result.Value;
                Assert.True(carro.Nome == "Mercedes");

            }
        }

        [Fact]
        public void TesteGetByIdNotFound()
        {
            InitializeDataBase();
            using (var contexto = new ProjAndreVeiculosAPICarroContext(options))
            {
                CarrosController controller = new CarrosController(contexto);
                ActionResult<Carro> carro = controller.GetCarro("ABC0010").Result;
                Assert.IsType<NotFoundResult>(carro.Result);
            }
        }

        [Fact]
        public void TestePost()
        {
            InitializeDataBase();
            using (var contexto = new ProjAndreVeiculosAPICarroContext(options))
            {
                CarrosController controller = new CarrosController(contexto);
                Carro carro = new Carro { Placa = "ABC0004", Nome = "Fiat", AnoFabricacao = 2020, AnoModelo = 2021, Cor = "Prata", Vendido = true };
                var car = controller.PostCarro(carro).Result.Value;
                Assert.Equal("Fiat", car.Nome);
            }
        }

    }


}

