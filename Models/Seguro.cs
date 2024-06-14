using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Seguro
    {
        [Key]
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Franquia { get; set; }
        public Carro Carro { get; set; }
        public Condutor CondutorPrincipal { get; set; }
    }
}
