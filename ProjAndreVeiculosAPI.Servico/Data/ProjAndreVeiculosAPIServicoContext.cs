using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosAPIServico.Data
{
    public class ProjAndreVeiculosAPIServicoContext : DbContext
    {
        public ProjAndreVeiculosAPIServicoContext (DbContextOptions<ProjAndreVeiculosAPIServicoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Servico> Servico { get; set; } = default!;
    }
}
