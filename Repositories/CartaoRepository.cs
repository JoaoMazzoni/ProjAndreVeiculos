using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CartaoRepository
    {
        private readonly string Conn;
        private readonly Faker _faker = new Faker("pt_BR");

        public void InsertCartao()
        {
            var cartao = new
            {
                NumeroCartao = _faker.Finance.CreditCardNumber(),
                CodigoSeguranca = _faker.Finance.CreditCardCvv(),
                DataValidade = _faker.Date.Future().ToString("MM/yy"),
                NomeCartao = _faker.Name.FullName()
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Cartao (NumeroCartao, CodigoSeguranca, DataValidade, NomeCartao) " +
                          "VALUES (@NumeroCartao, @CodigoSeguranca, @DataValidade, @NomeCartao)";
                connection.Execute(sql, cartao);
            }
        }


    }
}
