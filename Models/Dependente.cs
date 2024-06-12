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
        public static readonly string INSERTPESSOA = "INSERT INTO Pessoas (Documento, Nome, DataNascimento, Telefone, Email) VALUES (@Documento, @Nome, @DataNascimento, @Telefone, @Email)";
        public static readonly string GETCLIENTE = "SELECT Documento FROM Cliente AS C WHERE Documento = C.Documento";
        public static readonly string UPDATE = "UPDATE Dependente SET Cliente = @Cliente WHERE Documento = @Documento";
        public static readonly string DELETE = "DELETE FROM Dependente WHERE Documento = @Documento";
        public static readonly string GET = "SELECT Cliente FROM Dependente WHERE Documento = @Documento";
        public static readonly string GETALL = "SELECT * FROM Dependente";
        public static readonly string INSERTENDERECO = "INSERT INTO Endereco (Logradouro, CEP, Bairro, Complemento, Numero, Uf, Cidade) VALUES (@Logradouro, @CEP, @Bairro, @Complemento, @Numero, @Uf, @Cidade)";

        public Cliente Cliente { get; set; }
    }
}
