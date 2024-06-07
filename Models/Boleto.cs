using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Boleto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
