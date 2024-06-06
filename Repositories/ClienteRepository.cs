
using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace Repositories
{
    public class ClienteRepository
    {

        private readonly string Conn;
        private readonly Random _random = new Random();
        private readonly Faker _faker = new Faker();

        public ClienteRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        private string GetRandomElementFromArray(string[] array)
        {
            return array[_random.Next(array.Length)];
        }
        public void InsertCliente()
        {
            var nomes = new[] { "João", "Maria", "Vitória", "Pedro" };
            var telefones = new[] { "(16) 99765-4321", "(16) 99654-3210", "(16) 99543-2109", "(16) 99432-1098" };
            var documento = new[] { "111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44" };

            var cliente = new
            {
                Documento = GetRandomElementFromArray(documento),
                Nome = GetRandomElementFromArray(nomes),
                DataNascimento = DateTime.Now.AddYears(-_random.Next(18, 80)),
                EnderecoId = _random.Next(1, 10), 
                Telefone = GetRandomElementFromArray(telefones),
                Email = _faker.Internet.Email(),
                Renda = _random.Next(1500, 10000)
            };

            using (var connection = new SqlConnection(Conn))
            {
                var sql = "INSERT INTO Cliente (Documento, Nome, DataNascimento, EnderecoId, Telefone, Email, Renda) " +
                          "VALUES (@Documento, @Nome, @DataNascimento, @EnderecoId, @Telefone, @Email, @Renda)";
                connection.Execute(sql, cliente);
            }
        }

        
    }
}













//private string GenerateCpf()
//{
//    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
//    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
//    Random random = new Random();
//    string semente = random.Next(100000000, 999999999).ToString();
//    int soma = 0;

//    for (int i = 0; i < 9; i++)
//        soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

//    int resto = soma % 11;
//    if (resto < 2)
//        resto = 0;
//    else
//        resto = 11 - resto;

//    semente += resto.ToString();
//    soma = 0;

//    for (int i = 0; i < 10; i++)
//        soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

//    resto = soma % 11;
//    if (resto < 2)
//        resto = 0;
//    else
//        resto = 11 - resto;

//    semente += resto.ToString();

//    return Convert.ToUInt64(semente).ToString(@"000\.000\.000\-00");
//}