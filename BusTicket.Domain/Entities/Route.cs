using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Domain.Entities
{
    public sealed class Route
    {
        public int RouteId {  get; set; }
        public string PickUpLocation { get; set; }
        public string Destination { get;set; }

    }
}
