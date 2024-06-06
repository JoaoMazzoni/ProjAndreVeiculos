using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;

using System.Configuration;


namespace Repositories
{
    public class CarroRepository
    {
        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly Random _random = new Random(); 
        public CarroRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertCarro()
        {
            var carros = new[] { "ABC1234", "DEF5678", "GHI9101", "JKL1122" }; 

            var carro = new
            {
                Placa = GetRandomElementFromArray(carros),
                Nome = _faker.Vehicle.Model(),
                AnoModelo = _faker.Date.Past(10).Year,
                AnoFabricacao = _faker.Date.Past(11).Year,
                Cor = _faker.Commerce.Color(),
                Vendido = _faker.Random.Bool()
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Carro (Placa, Nome, AnoModelo, AnoFabricacao, Cor, Vendido) " +
                          "VALUES (@Placa, @Nome, @AnoModelo, @AnoFabricacao, @Cor, @Vendido)";
                connection.Execute(sql, carro);
            }
        }

        private string GetRandomElementFromArray(string[] array)
        {
            return array[_random.Next(array.Length)];
        }

    }
}
