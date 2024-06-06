using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Compra
    {
        public int Id { get; set; }
        public Carro Carro { get; set; }
        public Decimal Preco { get; set; }
        public DateTime DataCompra { get; set; }

    }
}