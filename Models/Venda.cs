using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Venda
    {
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public Carro Carro { get; set; }
        public DateTime DataVenda { get; set; }
        public Decimal ValorVenda { get; set; }
        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
