using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CompraRepository
    {
        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly Random _random = new Random();

        public CompraRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertCompra()
        {
            var carros = new[] { "ABC1234", "DEF5678", "GHI9101", "JKL1122" }; 

            var compra = new
            {
                CarroPlaca = GetRandomElementFromArray(carros),
                Preco = _faker.Commerce.Price(20000, 100000),
                DataCompra = _faker.Date.Recent()
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Compra (CarroPlaca, Preco, DataCompra) VALUES (@CarroPlaca,@Preco, @DataCompra)";
                connection.Execute(sql, compra);
            }
        }

        private string GetRandomElementFromArray(string[] array)
        {
            return array[_random.Next(array.Length)];
        }




    }
}
