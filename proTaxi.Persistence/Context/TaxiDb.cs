using Microsoft.EntityFrameworkCore;
using proTaxi.Domain.Entities;

namespace proTaxi.Persistence.Context
{
    public class TaxiDb : DbContext
    {
        public TaxiDb(DbContextOptions<TaxiDb> options):base(options) { }

        public DbSet<Taxiss> Taxis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<DetalleViaje> Detalles { get; set; }
    }
}
