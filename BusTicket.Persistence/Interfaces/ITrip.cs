using BusTicket.Domain.Entities;
using BusTicket.Domain.Interfaces;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Models.Route;
using BusTicket.Persistence.Models.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Interfaces
{
    public interface ITrip : IRepository<Trip, int>
    {
        Task<DataResult<TripModel>> GetTrip();
        Task<DataResult<TripModel>> GetTrip(string name);

    }
}
