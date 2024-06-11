using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Seguro
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Franquia { get; set; }
        public Carro Carro { get; set; }
        public Condutor CondutorPrincipal { get; set; }
    }
}
