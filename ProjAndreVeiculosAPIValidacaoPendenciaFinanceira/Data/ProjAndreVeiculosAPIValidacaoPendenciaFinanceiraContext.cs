using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPIValidacaoPendenciaFinanceira.Data
{
    public class ProjAndreVeiculosAPIValidacaoPendenciaFinanceiraContext : DbContext
    {
        public ProjAndreVeiculosAPIValidacaoPendenciaFinanceiraContext (DbContextOptions<ProjAndreVeiculosAPIValidacaoPendenciaFinanceiraContext> options)
            : base(options)
        {
        }

        public DbSet<Models.PendenciaFinanceira> PendenciaFinanceira { get; set; } = default!;
    }
}
