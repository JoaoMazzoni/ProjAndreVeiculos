using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Repositories
{
    public class BoletoRepository
    {
        
        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly Random _random = new Random();

        public BoletoRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertBoleto()
        {

            var boleto = new
            {
                Numero = _random.Next(100000, 999999),
                DataVencimento = _faker.Date.Future()
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Boleto (Numero, DataVencimento) VALUES (@Numero, @DataVencimento)";
                connection.Execute(sql, boleto);
            }
        }


    }
}
