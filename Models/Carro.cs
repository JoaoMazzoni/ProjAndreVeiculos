using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Carro
    {
        [Key]
        public string Placa { get; set; }
        public string Nome { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Cor { get; set; }
        public bool Vendido { get; set; }

    }
}
