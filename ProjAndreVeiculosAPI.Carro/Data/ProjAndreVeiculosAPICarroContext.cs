using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPICarro.Data
{
    public class ProjAndreVeiculosAPICarroContext : DbContext
    {
        public ProjAndreVeiculosAPICarroContext (DbContextOptions<ProjAndreVeiculosAPICarroContext> options)
            : base(options)
        {
        }

        public DbSet<Models.AceiteTermoUso> AceiteTermoUso { get; set; } = default!;
        public DbSet<Models.Banco> Banco { get; set; } = default!;
        public DbSet<Models.Boleto> Boleto { get; set; } = default!;
        public DbSet<Models.Cargo> Cargo { get; set; } = default!;
        public DbSet<Models.Carro> Carro { get; set; } = default!;
        public DbSet<Models.CarroServico> CarroServico { get; set; } = default!;
        public DbSet<Models.Cartao> Cartao { get; set; } = default!;       
        public DbSet<Models.Categoria> Categoria { get; set; } = default!;
        public DbSet<Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<Models.CNH> CNH { get; set; } = default!;
        public DbSet<Models.Compra> Compra { get; set; } = default!;
        public DbSet<Models.Condutor> Condutor { get; set; } = default!;
        public DbSet<Models.Dependente> Dependente { get; set; } = default!;
        public DbSet<Models.Endereco> Endereco { get; set; } = default!;
        public DbSet<Models.Financiamento> Finaciamento { get; set; } = default!;
        public DbSet<Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<Models.Pagamento> Pagamento { get; set; } = default!;
        public DbSet<Models.PendenciaFinanceira> PendenciaFinanceira { get; set; } = default!;
        public DbSet<Models.Pessoa> Pessoa { get; set; } = default!;
        public DbSet<Models.Pix> Pix { get; set; } = default!;
        public DbSet<Models.Seguro> Seguro { get; set; } = default!;
        public DbSet<Models.Servico> Servico { get; set; } = default!;
        public DbSet<Models.TermoDeUso> TermoDeUso { get; set; } = default!;
        public DbSet<Models.TipoPix> TipoPix { get; set; } = default!;
        public DbSet<Models.Venda> Venda { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura a chave primária na entidade raiz Pessoa
            modelBuilder.Entity<Banco>().HasKey(b => b.CNPJ);
            modelBuilder.Entity<Carro>().HasKey(c => c.Placa);
            modelBuilder.Entity<Cartao>().HasKey(c => c.NumeroCartao);
            modelBuilder.Entity<CNH>().HasKey(c => c.CNHNumero);
            modelBuilder.Entity<Pessoa>().HasKey(p => p.Documento);
            modelBuilder.Entity<Funcionario>().ToTable("Funcionario");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Dependente>().ToTable("Dependente");
            modelBuilder.Entity<Condutor>().ToTable("Condutor");


        }

    }
}
