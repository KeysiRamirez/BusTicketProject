using BusTicket.Domain.Entities;
using BusTicket.Domain.Interfaces;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Models.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Interfaces
{
    public interface IBus : IRepository<Bus, int>
    {
        Task<DataResult<BusModel>> GetBus();
        Task<DataResult<BusModel>> GetBus(string name);
    }
}
