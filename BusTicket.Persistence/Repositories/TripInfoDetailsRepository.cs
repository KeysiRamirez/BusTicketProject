using BusTicket.Domain.Entities;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Interfaces;
using BusTicket.Persistence.Models.TripInfoDetails;
using BusTicket.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Repositories
{
    public class TripInfoDetailsRepository : BaseRepository<TripInfoDetails, int>, ITripInfoDetails
    {
        public TripInfoDetailsRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public Task<DataResult<TripInfoDetailsModel>> GetTripInfoDetails()
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<TripInfoDetailsModel>> GetTripInfoDetails(string name)
        {
            throw new NotImplementedException();
        }

    }
}
