using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TermoDeUso
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Texto { get; set; }
        public int Versao { get; set; }
        public DateTime DataCadastro {  get; set; }
        public bool Status {  get; set; }

    }
}
