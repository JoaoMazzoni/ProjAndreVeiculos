using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarroServico
    {
        public int Id { get; set; }
        public Carro Carro { get; set; }

        public Servico Servico { get; set; }
    }
}
