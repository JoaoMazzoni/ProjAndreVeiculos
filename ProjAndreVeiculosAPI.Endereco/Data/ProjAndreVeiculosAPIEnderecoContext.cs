using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPIEndereco.Data
{
    public class ProjAndreVeiculosAPIEnderecoContext : DbContext
    {
        public ProjAndreVeiculosAPIEnderecoContext (DbContextOptions<ProjAndreVeiculosAPIEnderecoContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Endereco>().HasKey(p => p.Id);
        }
        public DbSet<Models.Endereco> Endereco { get; set; } = default!;
    }
}
