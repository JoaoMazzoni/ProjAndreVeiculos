using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Compra
    {
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public Carro Carro { get; set; }
        public Decimal Preco { get; set; }
        public DateTime DataCompra { get; set; }

    }
}