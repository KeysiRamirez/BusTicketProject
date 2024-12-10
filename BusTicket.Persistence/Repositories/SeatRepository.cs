using BusTicket.Domain.Entities;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Interfaces;
using BusTicket.Persistence.Models.Seat;
using BusTicket.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Repositories
{
    public sealed class SeatRepository : BaseRepository<Seat, int>, ISeat
    {
        public SeatRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<DataResult<SeatModel>> GetSeat()
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<SeatModel>> GetSeat(string name)
        {
            throw new NotImplementedException();
        }
    }

}
