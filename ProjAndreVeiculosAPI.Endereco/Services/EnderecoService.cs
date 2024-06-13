using Models;
using MongoDB.Driver;
using ProjAndreVeiculosAPIEndereco.Utilis;
using System.Net;

namespace ProjAndreVeiculosAPIEndereco.Services
{

    public class EnderecoService
    {
        private readonly IMongoCollection<Endereco> _endereco;

        public EnderecoService(IProjMongoDBAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _endereco = database.GetCollection<Endereco>(settings.AddressCollectionName);
        }

        public Endereco Create(Endereco address)
        {
             _endereco.InsertOne(address);

            return address;
        }
    }
}