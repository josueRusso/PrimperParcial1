using PrimerParcial.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcial.DAL
{
    public class Context : DbContext
    {
        public DbSet<Ingresos> Ingresos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
