using BusTicket.Domain.Entities;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Interfaces;
using BusTicket.Persistence.Models.BusDriver;
using BusTicket.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Repositories
{
    public sealed class BusDriverRepository : BaseRepository<BusDriver, int>, IBusDriver
    {
        public BusDriverRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<DataResult<BusDriverModel>> GetBusDriver()
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<BusDriverModel>> GetBusDriver(string name)
        {
            throw new NotImplementedException();
        }

    }
}
