using Microsoft.Data.SqlClient;
using Models;
using MongoDB.Driver.Core.Configuration;
using Newtonsoft.Json;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace ProjAndreVeiculosAPIDependente.Services
{
    public class EnderecoService
    {

        private static readonly HttpClient _httpClient = new HttpClient();
        static private string _connectionString;
        static private SqlConnection _conn;

        public EnderecoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ProjAndreVeiculosAPIDependenteContext");
            _conn = new SqlConnection(_connectionString);
            _conn.Open();
        }


        public async Task<Endereco> PostEndereco(Endereco endereco)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string cep = endereco.CEP;
                    client.BaseAddress = new Uri("https://viacep.com.br/");
                    var response = await client.GetAsync($"ws/{cep}/json/");
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        endereco = JsonConvert.DeserializeObject<Endereco>(stringResult);
                        
                    }
                    else
                    {
                        return null;
                    }
                }

                using (SqlCommand  cmd = new SqlCommand(Dependente.INSERTENDERECO, _conn))
                {
                    cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                    cmd.Parameters.AddWithValue("@CEP", endereco.CEP);
                    cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
                    cmd.Parameters.AddWithValue("@Complemento", endereco.Complemento);
                    cmd.Parameters.AddWithValue("@Numero", endereco.Numero);
                    cmd.Parameters.AddWithValue("@Uf", endereco.Uf);
                    cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
                    await cmd.ExecuteNonQueryAsync();

                    return endereco;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
