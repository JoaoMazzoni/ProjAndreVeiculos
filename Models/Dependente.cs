using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dependente : Pessoa
    {
        public static readonly string INSERT = "INSERT INTO Dependente (Dependente, Cliente) VALUES (@Dependente, @Cliente)";
        public static readonly string INSERTPESSOA = "INSERT INTO Pessoa (Documento, Nome, DataNascimento, Telefone, Email) VALUES (@Documento, @Nome, @DataNascimento, @Telefone, @Email)";

        public Cliente Cliente { get; set; }
        

    }
}
