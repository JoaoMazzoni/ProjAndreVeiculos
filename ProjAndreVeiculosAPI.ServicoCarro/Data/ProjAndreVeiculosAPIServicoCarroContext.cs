using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPICarroServico.Data
{
    public class ProjAndreVeiculosAPIServicoCarroContext : DbContext
    {
        public ProjAndreVeiculosAPIServicoCarroContext (DbContextOptions<ProjAndreVeiculosAPIServicoCarroContext> options)
            : base(options)
        {
        }

        public DbSet<Models.CarroServico> CarroServico { get; set; } = default!;
    }
}
