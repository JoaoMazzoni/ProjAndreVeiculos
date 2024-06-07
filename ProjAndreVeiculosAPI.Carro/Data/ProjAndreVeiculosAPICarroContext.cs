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

        public DbSet<Models.Carro> Carro { get; set; } = default!;
    }
}
