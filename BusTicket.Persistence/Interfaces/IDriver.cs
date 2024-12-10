using BusTicket.Domain.Entities;
using BusTicket.Domain.Interfaces;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Models.BusDriver;
using BusTicket.Persistence.Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Interfaces
{
    public interface IDriver : IRepository<Driver, int>
    {
        Task<DataResult<DriverModel>> GetDriver();
        Task<DataResult<DriverModel>> GetDriver(string name);
    }
}
