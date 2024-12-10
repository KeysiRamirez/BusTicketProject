using BusTicket.Domain.Entities;
using BusTicket.Domain.Interfaces;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Models.Route;
using BusTicket.Persistence.Models.Seat;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Interfaces
{
    public interface ISeat : IRepository<Seat, int>
    {
        Task<DataResult<SeatModel>> GetSeat();
        Task<DataResult<SeatModel>> GetSeat(string name);

    }
}
