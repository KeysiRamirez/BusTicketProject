using BusTicket.Data.Base;
using BusTicket.Data.Entities;
using BusTicket.Data.Models;
using System.Linq.Expressions;

namespace BusTicket.Data.Interfaces
{
    public class ITrip : IBaseRepository<Trip, int, TripModel>
    {
        public Task<bool> Exists(Expression<Func<Trip, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TripModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TripModel>>> GetAll(Expression<Func<Trip, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripModel>> Remove(Trip entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripModel>> Save(Trip entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripModel>> Update(Trip entity)
        {
            throw new NotImplementedException();
        }
    }
}
