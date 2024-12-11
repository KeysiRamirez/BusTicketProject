using BusTicket.Data.Base;
using BusTicket.Data.Entities;
using BusTicket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Interfaces
{
    public interface ITrip : IBaseRepository<Trip, int, TripModel>
    { 
        public Task<List<OperationResult<TripModel>>> GetTrip(int idTrip);

    }
}
