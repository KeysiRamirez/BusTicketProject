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
    public class ITripInfoDetails : IBaseRepository<TripInfoDetails, int, TripInfoDetailsModel>
    {
        public Task<bool> Exists(Expression<Func<TripInfoDetails, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TripInfoDetailsModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TripInfoDetailsModel>>> GetAll(Expression<Func<TripInfoDetails, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripInfoDetailsModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripInfoDetailsModel>> Remove(TripInfoDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripInfoDetailsModel>> Save(TripInfoDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripInfoDetailsModel>> Update(TripInfoDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
