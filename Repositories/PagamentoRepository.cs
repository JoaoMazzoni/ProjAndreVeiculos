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
    public class PagamentoRepository
    {
        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly Random _random = new Random();

        public PagamentoRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public void InsertPagamento()
        {
            var pagamentos = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Assumindo que existem 10 pagamentos
            var boletos = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Assumindo que existem 10 boletos
            var pixIds = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Assumindo que existem 10 Pix

            var pagamento = new
            {
                CartaoNumero = _faker.Finance.CreditCardNumber(),
                BoletoId = GetRandomElementFromArray(boletos),
                PixId = GetRandomElementFromArray(pixIds),
                DataPagamento = _faker.Date.Recent()
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Pagamento (CartaoNumero, BoletoId, PixId, DataPagamento) " +
                          "VALUES (@CartaoNumero, @BoletoId, @PixId, @DataPagamento)";
                connection.Execute(sql, pagamento);
            }
        }

        private int GetRandomElementFromArray(int[] array)
        {
            return array[_random.Next(array.Length)];
        }

    }
}
