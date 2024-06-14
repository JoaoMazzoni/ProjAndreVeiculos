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
                         e.Id, e.Logradouro, e.CEP, e.Bairro, e.TipoLogradouro, e.Complemento, e.Numero, e.Uf, e.Cidade,
                         car.Placa, car.Nome, car.AnoModelo, car.AnoFabricacao, car.Cor, car.Vendido,
                         cond.Documento, cond.CNHNumero,
                         cn.DataVencimento, cn.RG, cn.CPF, cn.NomeMae, cn.NomePai, 
	                     cat.Id AS CategoriaId, cat.Descricao AS CategoriaDescricao
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
                     INNER JOIN 
                         CNH cn ON cond.CNHNumero = cn.CNHNumero
                    LEFT JOIN 
                        Categoria cat ON cn.CategoriaId = cat.Id";


                    var seguros = db.Query<Seguro, Cliente, Endereco, Carro, Condutor, CNH, Categoria, Seguro>(
                    query,
                    (seguro, cliente, endereco, carro, condutor, cnh, categoria) =>
                    {
                        cliente.Nome = cliente.Nome;
                        cliente.DataNascimento = cliente.DataNascimento;
                        cliente.Telefone = cliente.Telefone;
                        cliente.Email = cliente.Email;
                        cliente.Endereco = endereco;

                        seguro.Cliente = cliente;
                        seguro.Carro = carro;

                    

                        seguro.CondutorPrincipal = condutor;

                        seguro.CondutorPrincipal.CNH = cnh;

                        seguro.CondutorPrincipal.CNH.Categoria = categoria;

                        return seguro;
                    }
                   // ,splitOn: "Documento,EnderecoId,Placa,CondutorDocumento,CNHNumero,CategoriaId"
                     ,splitOn: "Documento,EnderecoId,Placa, Documento,CNHNumero,CategoriaId"
                ).ToList();

                return seguros;




            }
        }
    }
}
