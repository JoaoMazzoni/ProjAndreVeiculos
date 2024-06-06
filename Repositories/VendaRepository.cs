

using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace Repositories
{
    public class VendaRepository
    {
        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly Random _random = new Random();

        public VendaRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public void InsertVenda()
        {
            var carros = new[] { "ABC1234", "DEF5678", "GHI9101", "JKL1122" }; // Exemplo de placas
            var clientes = new[] { "111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44" }; // Exemplo de CPFs
            var funcionarios = new[] { "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88" }; // Exemplo de CPFs
            var pagamentos = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Assumindo que existem 10 pagamentos

            var venda = new
            {
                CarroPlaca = GetRandomElementFromArray(carros),
                DataVenda = _faker.Date.Recent(),
                ValorVenda = _faker.Commerce.Price(20000, 100000),
                ClienteDocumento = GetRandomElementFromArray(clientes),
                FuncionarioDocumento = GetRandomElementFromArray(funcionarios),
                PagamentoId = GetRandomElementFromArray(pagamentos)
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Venda (CarroPlaca, DataVenda, ValorVenda, ClienteDocumento, FuncionarioDocumento, PagamentoId) " +
                          "VALUES (@CarroPlaca, @DataVenda, @ValorVenda, @ClienteDocumento, @FuncionarioDocumento, @PagamentoId)";
                connection.Execute(sql, venda);
            }
        }

        private string GetRandomElementFromArray(string[] array) //Sobrecarga
        {
            return array[_random.Next(array.Length)];
        }

        private int GetRandomElementFromArray(int[] array) //Sobrecarga
        {
            return array[_random.Next(array.Length)];
        }




    }
}
