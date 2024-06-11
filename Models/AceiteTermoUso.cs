using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AceiteTermoUso
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public TermoDeUso TermoDeUso { get; set; }
        public DateTime DataAceite {  get; set; }
    }
}
