using BusTicket.Domain.Entities;
using BusTicket.Domain.Interfaces;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Models.Trip;
using BusTicket.Persistence.Models.TripInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Interfaces
{
    public interface ITripInfo : IRepository<TripInfo, int>
    {
        Task<DataResult<TripInfoModel>> GetTripInfo();
        Task<DataResult<TripInfoModel>> GetTripInfo(string name);

    }
}
