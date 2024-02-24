using Microsoft.EntityFrameworkCore;
using static PruebaTransacciones.Dto.Transaccion;

namespace PruebaTransacciones.Data
{
    public class YourBDContext: DbContext
    {
        public YourBDContext(DbContextOptions<YourBDContext> options) : base(options)
        { }

        public DbSet<Transacciones> Transacciones { get; set; }
        public DbSet<Vehiculos> vehiculos{ get; set; }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Concesionarios> concesionarios { get; set; }

    }
}
