using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Cartao
    {
        [Key]
        public string NumeroCartao { get; set; }
        public string CodigoSeguranca { get; set; }
        public DateTime DataValidade { get; set; }
        public string NomeCartao { get; set; }
    }
}
