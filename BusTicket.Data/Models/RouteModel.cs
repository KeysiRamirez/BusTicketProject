﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Models
{
    public class RouteModel
    {
        public int IdRuta { get; set; }
        public string PickUpLocation { get; set; }
        public string Destination { get; set; }
    }
}