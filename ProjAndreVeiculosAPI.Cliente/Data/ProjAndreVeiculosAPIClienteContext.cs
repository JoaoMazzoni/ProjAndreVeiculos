using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPICliente.Data
{
    public class ProjAndreVeiculosAPIClienteContext : DbContext
    {
        public ProjAndreVeiculosAPIClienteContext (DbContextOptions<ProjAndreVeiculosAPIClienteContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura a chave primária na entidade raiz Pessoa
            modelBuilder.Entity<Pessoa>().HasKey(p => p.Documento);
            modelBuilder.Entity<Models.Cliente>().ToTable("Cliente");
        }
        public DbSet<Models.Cliente>? Cliente { get; set; } = default!;
        public DbSet<Models.Pessoa>? Pessoas { get; set; } = default!;

    }
}
