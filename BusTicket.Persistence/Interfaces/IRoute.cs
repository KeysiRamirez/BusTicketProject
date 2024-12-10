using BusTicket.Domain.Entities;
using BusTicket.Domain.Interfaces;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Models.Route;


namespace BusTicket.Persistence.Interfaces
{
    public interface IRoute : IRepository <Route, int>
    {
        Task<DataResult<RouteModel>> GetRoute();
        Task<DataResult<RouteModel>> GetRoute(string name);

    }
}
