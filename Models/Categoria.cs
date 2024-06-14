using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Categoria
    {
        [Key]
        public long Id { get; set; }
        public string Descricao { get; set; }
    }
}
