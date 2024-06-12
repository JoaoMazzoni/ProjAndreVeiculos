using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AceiteTermoUso
    {
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public TermoDeUso TermoDeUso { get; set; }
        public DateTime DataAceite {  get; set; }
    }
}
