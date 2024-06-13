using Dapper;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjAndreVeiculosAPIFinanciamento.Repositories
{
    public class FinanciamentoRepository
    {
        private string Conn { get; set; }

        public FinanciamentoRepository()
        {
            // Certifique-se de que o pacote System.Configuration.ConfigurationManager está instalado
            Conn = System.Configuration.ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public bool Inserir(Financiamento financiamento)
        {
            var status = false;

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute("INSERT INTO TB_PEDIDO (VendaId, DataFinanciamento, BancoCNPJ) VALUES (@VendaId, @DataFinanciamento, @BancoCNPJ)", new
                {
                    VendaId = financiamento.Venda.Id,
                    DataFinanciamento = financiamento.DataFinanciamento,
                    BancoCNPJ = financiamento.Banco.CNPJ
                });
                status = true;
                db.Close();
            }

            return status;
        }

        public List<Financiamento> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();

                var financiamentos = db.Query<Financiamento, Venda, Banco, Financiamento>(
                    "SELECT * FROM TB_PEDIDO AS f INNER JOIN Venda AS v ON f.VendaId = v.Id INNER JOIN Banco AS b ON f.BancoCNPJ = b.CNPJ",
                    (financiamento, venda, banco) =>
                    {
                        financiamento.Venda = venda;
                        financiamento.Banco = banco;
                        return financiamento;
                    },
                    splitOn: "VendaId,BancoCNPJ"
                ).ToList();

                return financiamentos;
            }
        }
    }
}


