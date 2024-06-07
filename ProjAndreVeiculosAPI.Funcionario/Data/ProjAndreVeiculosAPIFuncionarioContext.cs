using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPIFuncionario.Data
{
    public class ProjAndreVeiculosAPIFuncionarioContext : DbContext
    {
        public ProjAndreVeiculosAPIFuncionarioContext (DbContextOptions<ProjAndreVeiculosAPIFuncionarioContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura a chave primária na entidade raiz Pessoa
            modelBuilder.Entity<Pessoa>().HasKey(p => p.Documento);
        }
        public DbSet<Models.Funcionario> Funcionario { get; set; } = default!;
    }
}
