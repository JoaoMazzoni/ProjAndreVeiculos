using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cartao
    {
        public string NumeroCartao { get; set; }
        public string CodigoSeguranca { get; set; }
        public string DataValidade { get; set; }
        public string NomeCartao { get; set; }
    }
}
