using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Categoria
    {
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public long Id { get; set; }
        public string Descricao { get; set; }
    }
}
