using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Models
{
    public class Financiamento
    {
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public Venda Venda { get; set; }
        public DateTime DataFinanciamento { get; set; }
        public Banco Banco { get; set; }

    }
}
