using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Models
{
    public class TripModel
    {
        public int IdViaje { get; set; }
        public int IdBus { get; set; }
        public int IdRuta { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime HoraLlegada { get; set; }
        public decimal Precio { get; set; }
        public int TotalAsientos { get; set; }
        public int AsientosReservados { get; set; }
        public int AsientoDisponibles { get; set; }
        public bool Completo { get; set; }

    }
}
