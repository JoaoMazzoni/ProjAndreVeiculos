using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPICompra.Data
{
    public class ProjAndreVeiculosAPICompraContext : DbContext
    {
        public ProjAndreVeiculosAPICompraContext (DbContextOptions<ProjAndreVeiculosAPICompraContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Compra> Compra { get; set; } = default!;
    }
}
