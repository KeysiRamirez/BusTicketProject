using BusTicket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Context
{
    public class BusTicketDb : DbContext
    {
        public BusTicketDb(DbContextOptions<BusTicketDb> options) : base(options) 
        {

        }
    
        // For mapping
        public DbSet<Bus> Bus { get; set; }
        public DbSet<Seat> Asiento { get; set; }
        public DbSet<Driver> Conductor { get; set; }
        public DbSet<BusDriver> ConductorBus { get; set; }
        public DbSet<Trip> Viaje { get; set; }
        public DbSet<TripInfo> Reserva { get; set; }
        public DbSet<TripInfoDetails> ReservaDetalle { get; set; }
        public DbSet<Route> Ruta { get; set; }
        public DbSet<User> Usuario { get; set; }

    }
}
