using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Models
{
    public class TripInfoModel
    {
        public int IdReserva { get; set; }
        public int IdViaje { get; set; }
        public int IdPasajero { get; set; }
        public int AsientosReservados { get; set; }
        public decimal MontoTotal { get; set; }

    }
}
