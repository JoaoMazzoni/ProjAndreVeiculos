using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Funcionario : Pessoa
    {
        public Cargo Cargo { get; set; }
        public Decimal ValorComissao { get; set; }
        public Decimal Comissao { get; set; }
    }
}
