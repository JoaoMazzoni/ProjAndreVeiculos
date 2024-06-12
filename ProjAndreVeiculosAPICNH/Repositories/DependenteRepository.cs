using Microsoft.Data.SqlClient;
using Models;
using ProjAndreVeiculosAPICliente.Controllers;
using ProjAndreVeiculosAPIDependente.Services;

namespace ProjAndreVeiculosAPIDependente.Repositories
{
    public class DependenteRepository
    {
        static private string _connectionString;
        static private SqlConnection _conn;
        private readonly EnderecoService _enderecoService;
        
        public DependenteRepository(IConfiguration configuration, EnderecoService enderecoService)
        {
            _connectionString = configuration.GetConnectionString("ProjAndreVeiculosAPIDependenteContext");
            _conn = new SqlConnection(_connectionString);
            _conn.Open();
            _enderecoService = enderecoService;

        }

        public async Task<IEnumerable<Dependente>> GetAll()
        {
            var dependentes = new List<Dependente>();

            using (SqlCommand cmd = new SqlCommand(Dependente.GETALL, _conn))
            {
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        dependentes.Add(new Dependente
                        {
                            Documento = reader.GetString(0),
                            Nome = reader.GetString(1),
                            DataNascimento = reader.GetDateTime(2),
                            Telefone = reader.GetString(3),
                            Email = reader.GetString(4)
                        });
                    }
                }
            }

            return dependentes;
        }

        public async Task<Dependente> GetById(string documento)
        {
            Dependente dependente = null;

            using (SqlCommand cmd = new SqlCommand(Dependente.GET, _conn))
            {
                cmd.Parameters.AddWithValue("@Documento", documento);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        dependente = new Dependente
                        {
                            Documento = reader.GetString(0),
                            Nome = reader.GetString(1),
                            DataNascimento = reader.GetDateTime(2),
                            Telefone = reader.GetString(3),
                            Email = reader.GetString(4)      
                        };
                    }
                }
            }

            return dependente;
        }

        public async Task Add(Dependente dependente)
        {
            using (SqlCommand cmd = new SqlCommand(Dependente.INSERTPESSOA, _conn))
            {
                cmd.Parameters.AddWithValue("@Documento", dependente.Documento) ;
                cmd.Parameters.AddWithValue("@Nome", dependente.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", dependente.DataNascimento);
                cmd.Parameters.AddWithValue("@Telefone", dependente.Telefone);
                cmd.Parameters.AddWithValue("@Email", dependente.Email);
                
                await cmd.ExecuteNonQueryAsync();
            }

            Endereco endereco = _enderecoService.PostEndereco(dependente.Endereco).Result;
            dependente.Endereco = endereco;


            using (SqlCommand cmd = new SqlCommand(Dependente.INSERT, _conn))
            {
                cmd.Parameters.AddWithValue("@Dependente", dependente.Documento);
                cmd.Parameters.AddWithValue("@Cliente", dependente.Cliente.Documento);
                await cmd.ExecuteNonQueryAsync();
            }


        }

        public async Task Update(Dependente dependente)
        {
            using (SqlCommand cmd = new SqlCommand(Dependente.UPDATE, _conn))
            {
                cmd.Parameters.AddWithValue("@Documento", dependente.Documento);
                cmd.Parameters.AddWithValue("@Nome", dependente.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", dependente.DataNascimento);
                cmd.Parameters.AddWithValue("@Telefone", dependente.Telefone);
                cmd.Parameters.AddWithValue("@Email", dependente.Email);
                await cmd.ExecuteNonQueryAsync();
            }
        }



        public async Task DeleteAsync(string documento)
        {
            using (SqlCommand cmd = new SqlCommand(Dependente.DELETE, _conn))
            {
                cmd.Parameters.AddWithValue("@Documento", documento);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}