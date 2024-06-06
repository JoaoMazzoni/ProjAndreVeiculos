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
    public class CarroServicoRepository
    {

        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly Random _random = new Random();

        public CarroServicoRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertCarroServico()
        {
            var carros = new[] { "ABC1234", "DEF5678", "GHI9101", "JKL1122" }; 
            var servicos = new[] { 1, 2, 3, 4, 5 }; 

            var carroServico = new
            {
                CarroPlaca = GetRandomElementFromArray(carros),
                ServicoId = GetRandomElementFromArray(servicos)
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO CarroServico (CarroPlaca, ServicoId) VALUES (@CarroPlaca, @ServicoId)";
                connection.Execute(sql, carroServico);
            }
        }

        private string GetRandomElementFromArray(string[] array)
        {
            return array[_random.Next(array.Length)];
        }

        private int GetRandomElementFromArray(int[] array)
        {
            return array[_random.Next(array.Length)];
        }


    }
}
