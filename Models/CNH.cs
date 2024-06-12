using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CNH
    {
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public long CNHNumero { get; set; }
        public DateTime DataVencimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public Categoria Categoria { get; set; }
        
    }
}
