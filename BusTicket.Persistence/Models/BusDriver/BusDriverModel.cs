using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Models.BusDriver
{
    public class BusDriverModel
    {
        public int ConductorBusID { get; set; }
        public int ConductorID { get; set; }
        public int BusId { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
