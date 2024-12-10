using BusTicket.Domain.Entities;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Interfaces;
using BusTicket.Persistence.Models.Route;
using BusTicket.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Repositories
{
    public sealed class RouteRepository : BaseRepository<Route, int>, IRoute
    {
        public RouteRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<DataResult<RouteModel>> GetRoute()
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<RouteModel>> GetRoute(string name)
        {
            throw new NotImplementedException();
        }
    }
}
