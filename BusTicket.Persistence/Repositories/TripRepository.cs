using BusTicket.Domain.Entities;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Interfaces;
using BusTicket.Persistence.Models.Trip;
using BusTicket.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace BusTicket.Persistence.Repositories
{
    public sealed class TripRepository : BaseRepository<Trip, int>, ITrip
    {
        public TripRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<DataResult<TripModel>> GetTrip() 
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<TripModel>> GetTrip(string name)
        {
            throw new NotImplementedException();
        }

    }
}
