using BusTicket.Domain.Entities;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Interfaces;
using BusTicket.Persistence.Models.TripInfo;
using BusTicket.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Repositories
{
    public sealed class TripInfoRepository : BaseRepository<TripInfo, int>, ITripInfo
    {
        public TripInfoRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<DataResult<TripInfoModel>> GetTripInfo() 
        {
            throw new NotImplementedException();
        }
        public Task<DataResult<TripInfoModel>> GetTripInfo(string name)
        {
            throw new NotImplementedException();
        }



    }
}
