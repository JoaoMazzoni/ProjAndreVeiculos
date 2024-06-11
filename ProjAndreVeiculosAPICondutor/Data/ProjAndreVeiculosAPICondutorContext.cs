using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPICondutor.Data
{
    public class ProjAndreVeiculosAPICondutorContext : DbContext
    {
        public ProjAndreVeiculosAPICondutorContext (DbContextOptions<ProjAndreVeiculosAPICondutorContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Pessoa>().HasKey(p => p.Documento); 
            modelBuilder.Entity<Models.Condutor>().ToTable("Condutor");

        }

        public DbSet<Models.CNH> CNH { get; set; } = default!;

        public DbSet<Models.Condutor>? Condutor { get; set; }

        public DbSet<Models.Pessoa> Pessoas { get; set; }

        public DbSet<Models.Endereco>? Endereco { get; set; }
     
    }
}
