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
    public class ServicoRepository
    {
        private readonly string Conn;
        private readonly Random _random = new Random();

        public ServicoRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertServico()
        {
            var servicos = new[] { "Troca de óleo", "Alinhamento", "Balanceamento", "Troca de pneus", "Pintura" };

            var servico = new
            {
                Descricao = GetRandomElementFromArray(servicos)
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Servico (Descricao) VALUES (@Descricao)";
                connection.Execute(sql, servico);
            }
        }

        private string GetRandomElementFromArray(string[] array)
        {
            return array[_random.Next(array.Length)];
        }

    }
}
