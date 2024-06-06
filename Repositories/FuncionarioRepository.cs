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
    public class FuncionarioRepository
    {
        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly Random _random = new Random();

        public FuncionarioRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public void InsertFuncionario()
        {
            var cargos = new[] { 1, 2, 3, 4 }; 
            var documento = new[] { "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88" };
            var funcionario = new
            {
                Documento = GetRandomElementFromArray(documento),
                Nome = _faker.Name.FullName(),
                DataNascimento = _faker.Date.Past(50, DateTime.Now.AddYears(-18)),
                EnderecoId = _random.Next(1, 10), 
                Telefone = _faker.Phone.PhoneNumber("(##) #####-####"),
                Email = _faker.Internet.Email(),
                CargoId = GetRandomElementFromArray(cargos), 
                ValorComissao = _faker.Finance.Amount(500, 5000),
                Comissao = _faker.Finance.Amount(0.01m, 0.1m)
            };


        }

        private int GetRandomElementFromArray(int[] array)
        {
            return array[_random.Next(array.Length)];
        }

        private string GetRandomElementFromArray(string[] array)
        {
            return array[_random.Next(array.Length)];
        }

    }
}
