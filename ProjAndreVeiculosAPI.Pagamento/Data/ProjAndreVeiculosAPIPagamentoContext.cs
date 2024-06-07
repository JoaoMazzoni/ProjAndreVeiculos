using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPIPagamento.Data
{
    public class ProjAndreVeiculosAPIPagamentoContext : DbContext
    {
        public ProjAndreVeiculosAPIPagamentoContext (DbContextOptions<ProjAndreVeiculosAPIPagamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Pagamento> Pagamento { get; set; } = default!;
    }
}
