using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
