using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Banco
    {
        [Key]
        public string CNPJ {  get; set; }
        public string NomeBanco { get; set; }
        public DateTime DataFundacao { get; set; }

    }
}
