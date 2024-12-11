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
    public interface ISeat : IBaseRepository<Seat, int, SeatModel>
    {
        public Task<List<OperationResult<SeatModel>>> GetSeat(int idSeat);

    }
}
