using BusTicket.Domain.Entities;
using BusTicket.Domain.Interfaces;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Models.BusDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Interfaces
{
    public interface IBusDriver : IRepository<BusDriver, int>
    {
        Task<DataResult<BusDriverModel>> GetBusDriver();
        Task<DataResult<BusDriverModel>> GetBusDriver(string name);
    }
}
