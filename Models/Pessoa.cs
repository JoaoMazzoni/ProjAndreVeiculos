using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class Pessoa
    {
        [Key]
        public string Documento { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone   { get; set; }
        public string Email { get; set; }

    }
}
