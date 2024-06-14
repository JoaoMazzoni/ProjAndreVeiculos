using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjAndreVeiculosAPISeguro.Repositories
{
    public class SeguroRepository
    {
        private string Conn { get; set; }

        public SeguroRepository()
        {
            // Certifique-se de que o pacote System.Configuration.ConfigurationManager está instalado
            Conn = System.Configuration.ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public bool PostSeguro(Seguro seguro)
        {
            var status = false;

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute("INSERT INTO Seguro (ClienteDocumento, Franquia, Placa, CondutorPrincipalId) VALUES (@ClienteDocumento, @Franquia, @Placa, @CondutorPrincipalId)", new
                {
                    ClienteDocumento = seguro.Cliente.Documento,
                    Franquia = seguro.Franquia,
                    Placa = seguro.Carro.Placa,
                    CondutorPrincipalId = seguro.CondutorPrincipal.Documento
                });
                status = true;
                db.Close();
            }

            return status;
        }

        public List<Seguro> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();

                var query = @"
                    SELECT 
                        s.Id,
                        s.Franquia,
                        cli.Documento, cli.Renda, cli.DocumentoPDF, 
                        p.Nome, p.DataNascimento, p.Telefone, p.Email, p.EnderecoId,
                        e.Logradouro, e.CEP, e.Bairro, e.TipoLogradouro, e.Complemento, e.Numero, e.Uf, e.Cidade,
                        car.Placa, car.Nome, car.AnoModelo, car.AnoFabricacao, car.Cor, car.Vendido,
                        cond.Documento AS CondutorDocumento, cond.CNHNumero,
                        cn.DataVencimento, cn.RG, cn.CPF, cn.NomeMae, cn.NomePai, cn.CategoriaId
                    FROM 
                        Seguro s
                    INNER JOIN 
                        Cliente cli ON s.ClienteDocumento = cli.Documento
                    INNER JOIN 
                        Pessoas p ON cli.Documento = p.Documento
                    INNER JOIN 
                        Endereco e ON p.EnderecoId = e.Id
                    INNER JOIN 
                        Carro car ON s.Placa = car.Placa
                    INNER JOIN 
                        Condutor cond ON s.CondutorPrincipalId = cond.Documento
                    LEFT JOIN 
                        CNH cn ON cond.CNHNumero = cn.CNHNumero";

                var seguros = db.Query<Seguro, Cliente, Carro, Condutor, Seguro>(
                    query,
                    (seguro, cliente, carro, condutor) =>
                    {
                        cliente.Nome = cliente.Nome; // Associa nome de Pessoa a Cliente
                        cliente.DataNascimento = cliente.DataNascimento; // Associa data de nascimento de Pessoa a Cliente
                        cliente.Telefone = cliente.Telefone; // Associa telefone de Pessoa a Cliente
                        cliente.Email = cliente.Email; // Associa email de Pessoa a Cliente
                        cliente.Endereco = cliente.Endereco; // Associa endereço de Pessoa a Cliente
                        seguro.Cliente = cliente;
                        seguro.Carro = carro;
                        seguro.CondutorPrincipal = condutor;
                        return seguro;
                    },
                    splitOn: "Documento,Placa,CondutorDocumento"
                ).ToList();

                return seguros;
            }
        }
    }
}
