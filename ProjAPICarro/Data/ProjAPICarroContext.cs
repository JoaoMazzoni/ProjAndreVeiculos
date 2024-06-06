using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAPICarro.Data
{
    public class ProjAPICarroContext : DbContext
    {
        public ProjAPICarroContext (DbContextOptions<ProjAPICarroContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Carro> Carro { get; set; } = default!;
    }
}
