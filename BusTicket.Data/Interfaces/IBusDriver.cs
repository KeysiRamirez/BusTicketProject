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
    public interface IBusDriver : IBaseRepository<BusDriver, int, BusDriverModel>
    {
        public Task<List<OperationResult<BusDriverModel>>> GetBusDriver(int idBusDriver);
    }
}
