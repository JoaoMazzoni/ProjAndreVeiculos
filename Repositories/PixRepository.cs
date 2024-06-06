using Bogus;
using Bogus.Extensions.Brazil;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace Repositories
{
    public class PixRepository
    {
        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly Random _random = new Random();

        public PixRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertPix()
        {
            // Tipos de Pix: " 1 = Chave Aleatória", " 2 = CPF", "3 = Telefone", "4 = E-mail"
            var tiposPix = new[] { 1, 2, 3, 4 };

            var tipoId = GetRandomElementFromArray(tiposPix);
            var chavePix = GenerateChavePix(tipoId);

            var pix = new
            {
                TipoId = tipoId,
                ChavePix = chavePix
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Pix (TipoId, ChavePix) VALUES (@TipoId, @ChavePix)";
                connection.Execute(sql, pix);
            }
        }

        private int GetRandomElementFromArray(int[] array)
        {
            return array[_random.Next(array.Length)];
        }

        private string GenerateChavePix(int tipoId)
        {
            return tipoId switch
            {
                1 => _faker.Random.Replace("????????-????-????-????-????????????"), // Chave Aleatória
                2 => _faker.Person.Cpf(includeFormatSymbols: true), // CPF
                3 => _faker.Phone.PhoneNumber("(##) #####-####"), // Telefone
                4 => _faker.Internet.Email(), // E-mail
                _ => throw new ArgumentOutOfRangeException(nameof(tipoId), "TipoId inválido")
            };
        }
    }
}
