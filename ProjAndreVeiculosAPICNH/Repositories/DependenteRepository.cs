using Microsoft.Data.SqlClient;
using Models;

namespace ProjAndreVeiculosAPIDependente.Repositories
{
    public class DependenteRepository
    {
        static private string _connectionString;
        static private SqlConnection _conn;

        public DependenteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ProjAndreVeiculosAPIDependenteContext");
            _conn = new SqlConnection(_connectionString);
            _conn.Open();
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
                cmd.Parameters.AddWithValue("@Document", documento);

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

            using (SqlCommand cmd = new SqlCommand(Dependente.INSERT, _conn))
            {
                cmd.Parameters.AddWithValue("@Documento", dependente.Documento);
                cmd.Parameters.AddWithValue("@Nome", dependente.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", dependente.DataNascimento);
                cmd.Parameters.AddWithValue("@Telefone", dependente.Telefone);
                cmd.Parameters.AddWithValue("@Email", dependente.Email);
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