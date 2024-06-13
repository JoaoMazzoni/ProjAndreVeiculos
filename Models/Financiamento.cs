using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Financiamento
    {
        public int Id { get; set; }
        public Venda Venda { get; set; }
        public DateTime DataFinanciamento { get; set; }
        public Banco Banco { get; set; }

    }
}
