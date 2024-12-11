using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Models
{
    public class TripInfoDetailsModel
    {
        public int IdReservaDetalle { get; set; }
        public int IdReserva { get; set; }
        public int IdAsiento { get; set; }
    }
}
