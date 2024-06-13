using Models;
using MongoDB.Driver;
using ProjAndreVeiculosAPITermoUso.Utilis;

namespace ProjAndreVeiculosAPITermoUso.Services
{
    public class TermoUsoService
    {
        private readonly IMongoCollection<TermoDeUso> _termo;

        public TermoUsoService(IProjMongoDBAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _termo = database.GetCollection<TermoDeUso>(settings.TermoCollectionName);
        }

        public List<TermoDeUso> GetTermos() => _termo.Find(termo => true).ToList();

        public TermoDeUso Create(TermoDeUso termo)
        {
            _termo.InsertOne(termo);

            return termo;
        }


    }
}
