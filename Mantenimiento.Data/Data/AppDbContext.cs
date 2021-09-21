using Mantenimiento.Common.Models;
using System.Data.Entity;

namespace Mantenimiento.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext():base("Name=DefaultConnection")
        {

        }

        public virtual DbSet<Empleados> Empleados { get; set; }
    }
}
