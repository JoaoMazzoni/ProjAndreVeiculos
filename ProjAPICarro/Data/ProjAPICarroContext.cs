using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAPICarro.Data
{
    public class ProjAPICarroContext : DbContext
    {
        public ProjAPICarroContext(DbContextOptions<ProjAPICarroContext> options) : base(options)
        {
        }

        public DbSet<Models.Carro> Carro { get; set; } = default!;
        public DbSet<Models.Pessoa>? Pessoas { get; set; } = default!;
        public DbSet<Models.Cliente>? Cliente { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura a chave primária na entidade raiz Pessoa
            modelBuilder.Entity<Pessoa>().HasKey(p => p.Documento);
        }



    }
}