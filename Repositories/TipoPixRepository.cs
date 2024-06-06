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
    public class TipoPixRepository
    {
        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly Random _random = new Random();

        public TipoPixRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertTipoPix()
        {
            var tiposPix = new[] { "Chave Aleatória", "CPF", "Telefone", "E-mail" };

            var tipoPix = new
            {
                Nome = GetRandomElementFromArray(tiposPix)
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO TipoPix (Nome) VALUES (@Nome)";
                connection.Execute(sql, tipoPix);
            }
        }

        private string GetRandomElementFromArray(string[] array)
        {
            return array[_random.Next(array.Length)];
        }


    }
}
