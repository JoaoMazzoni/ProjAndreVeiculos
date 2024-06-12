using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Pagamento
    {
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public Cartao? Cartao { get; set; }
        public Boleto? Boleto { get; set; }
        public Pix? Pix { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
