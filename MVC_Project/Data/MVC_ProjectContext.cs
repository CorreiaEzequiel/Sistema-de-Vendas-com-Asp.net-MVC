using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Data
{
    public class MVC_ProjectContext : DbContext
    {
        public MVC_ProjectContext (DbContextOptions<MVC_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Departaments> Departaments { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<RegistroVendas> RegistroVendas { get; set; }

    }
}
