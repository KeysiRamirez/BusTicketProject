using BusTicket.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace BusTicket.Data.Context
{
    public class BoletoContext : DbContext
    {
        public BoletoContext(DbContextOptions<BoletoContext> options) : base(options)
        {


        }

        #region "DBSets"
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Seat> Asiento { get; set; }
        public DbSet<Driver> Conductor { get; set; }
        public DbSet<BusDriver> ConductorBus { get; set; }
        public DbSet<Trip> Viaje { get; set; }
        public DbSet<TripInfo> Reserva { get; set; }
        public DbSet<TripInfoDetails> ReservaDetalle { get; set; }
        public DbSet<Route> Ruta { get; set; }
        public DbSet<User> Usuario { get; set; }

        #endregion
    }
}
