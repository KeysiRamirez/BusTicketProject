using BusTicket.Domain.Entities;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Interfaces;
using BusTicket.Persistence.Models.Bus;
using BusTicket.Persistence.Repository;
using Microsoft.EntityFrameworkCore;


namespace BusTicket.Persistence.Repositories
{
    public sealed class BusRepository : BaseRepository<Bus, int>, IBus
    {
        public BusRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public Task<DataResult<BusModel>> GetBus() 
        { 
            throw new NotImplementedException();
        }

        public Task<DataResult<BusModel>> GetBus(string name)
        {
            throw new NotImplementedException();
        }
    }
}
