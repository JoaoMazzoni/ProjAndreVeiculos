using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Endereco
    {

        public int Id { get; set; }
        public  string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string TipoLogradouro { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
    }
}
