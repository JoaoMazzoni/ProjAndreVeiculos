using Microsoft.Data.SqlClient;
using Models;

namespace ProjAndreVeiculosAPIDependente.Repositories
{
    public class DependenteRepository
    {
        static readonly string _connectionString = "Server=127.0.0.1; Database=DBProjAndreVeiculos; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True";
        static SqlConnection _connection;

        public DependenteRepository()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        
        public bool Post(Dependente dependente)
        {
            using (SqlCommand cmd = new SqlCommand(Dependente.INSERT, _connection))
            {
                cmd.Parameters.AddWithValue("@Dependente", dependente.Documento);
                cmd.Parameters.AddWithValue("@", time.DataCriacao);
                cmd.ExecuteNonQuery();
            }

        }
        public bool PostDependente (Dependente dependente)
        {
            using (SqlCommand cmd = new SqlCommand(Dependente.INSERTPESSOA, _connection))
            {
                cmd.Parameters.AddWithValue("@Documento", dependente.Documento);
                cmd.Parameters.AddWithValue("@Nome", dependente.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", dependente.DataNascimento);
                cmd.Parameters.AddWithValue("@Telefone", dependente.Telefone);
                cmd.Parameters.AddWithValue("@Email", dependente.Email);
                cmd.ExecuteNonQuery();


    }
}
    }
}
