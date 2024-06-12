using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TipoPix
    {
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
