using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;


namespace Repositories
{
    public class EnderecoRepository
    {

        private readonly string Conn;
        private readonly Random _random = new Random();

        public EnderecoRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertEndereco()
        {
            var logradouros = new[] { "Rua das Flores", "Rua do Bosque", "Rua das Árvores", "Rua do Sol" };
            var ceps = new[] { "12345-678", "98765-432", "54321-876", "87654-321" };
            var bairros = new[] { "Centro", "Jardim", "Vila", "Parque" };
            var tiposLogradouro = new[] { "Rua", "Avenida", "Travessa", "Alameda" };
            var complementos = new[] { "Apto 101", "Apto 202", "Apto 303", "Casa 1" };
            var ufs = new[] { "SP", "RJ", "MG", "PR" };
            var cidades = new[] { "São Paulo", "Rio de Janeiro", "Belo Horizonte", "Curitiba" };

            var endereco = new
            {
                Logradouro = GetRandomElementFromArray(logradouros),
                CEP = GetRandomElementFromArray(ceps),
                Bairro = GetRandomElementFromArray(bairros),
                TipoLogradouro = GetRandomElementFromArray(tiposLogradouro),
                Complemento = GetRandomElementFromArray(complementos),
                Numero = _random.Next(1, 1000),
                Uf = GetRandomElementFromArray(ufs),
                Cidade = GetRandomElementFromArray(cidades)
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Endereco (Logradouro, CEP, Bairro, TipoLogradouro, Complemento, Numero, Uf, Cidade) " +
                          "VALUES (@Logradouro, @CEP, @Bairro, @TipoLogradouro, @Complemento, @Numero, @Uf, @Cidade)";
                connection.Execute(sql, endereco);
            }
        }

        private string GetRandomElementFromArray(string[] array)
        {
            return array[_random.Next(array.Length)];
        }
    }
}
