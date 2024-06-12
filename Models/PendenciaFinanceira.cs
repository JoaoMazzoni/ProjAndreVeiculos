using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PendenciaFinanceira
    {
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPendencia { get; set; }
        public DateTime DataCobranca { get; set; }
        public bool Status { get; set; }
        public Cliente Cliente { get; set; }
    }
}
