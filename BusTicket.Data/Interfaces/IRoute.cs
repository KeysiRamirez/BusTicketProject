using BusTicket.Data.Base;
using BusTicket.Data.Entities;
using BusTicket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Interfaces
{
    public interface IRoute : IBaseRepository<Route, int, RouteModel>
    {
        public Task<OperationResult<List<RouteModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<RouteModel>>> GetAll(Expression<Func<Route, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RouteModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RouteModel>> Remove(Route entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RouteModel>> Save(Route entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RouteModel>> Update(Route entity)
        {
            throw new NotImplementedException();
        }
    }
}
