using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Models
{
    public class DriverModel
    {
        public int ConductorId { get; set; }
        public int Telefono { get; set; }
        public string NumeroLicencia { get; set; }
        public DateTime FechaContratacion { get; set; }
    }
}
