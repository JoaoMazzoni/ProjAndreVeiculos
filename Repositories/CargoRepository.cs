

using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;

using System.Configuration;

namespace Repositories
{
    public class CargoRepository
    {
        private readonly string Conn;
        private readonly Random _random = new Random();

        public CargoRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertCargo()
        {
            var cargos = new[] { "Gerente", "Assistente", "Vendedor", "Diretor", };

            var cargo = new
            {
                Descricao = GetRandomElementFromArray(cargos)
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Cargo (Descricao) VALUES (@Descricao)";
                connection.Execute(sql, cargo);
            }
        }

        private string GetRandomElementFromArray(string[] array)
        {
            return array[_random.Next(array.Length)];
        }
    }
    
}
