using BusTicket.Domain.Entities;
using BusTicket.Domain.Interfaces;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Models.Trip;
using BusTicket.Persistence.Models.TripInfo;
using BusTicket.Persistence.Models.TripInfoDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Interfaces
{
    public interface ITripInfoDetails : IRepository<TripInfoDetails, int>
    {
        Task<DataResult<TripInfoDetailsModel>> GetTripInfoDetails();
        Task<DataResult<TripInfoDetailsModel>> GetTripInfoDetails(string name);

    }
}
