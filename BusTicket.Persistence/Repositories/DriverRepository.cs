using BusTicket.Domain.Entities;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Interfaces;
using BusTicket.Persistence.Models.Driver;
using BusTicket.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Repositories
{
    public sealed class DriverRepository : BaseRepository<Driver, int>, IDriver
    {
        public DriverRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<DataResult<DriverModel>> GetDriver()
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<DriverModel>> GetDriver(string name)
        {
            throw new NotImplementedException();
        }
    }
}
