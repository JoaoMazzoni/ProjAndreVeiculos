using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TermoDeUso
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int Versao { get; set; }
        public DateTime DataCadastro {  get; set; }
        public bool Status {  get; set; }

    }
}
