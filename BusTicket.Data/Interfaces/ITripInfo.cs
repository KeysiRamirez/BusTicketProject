
using BusTicket.Data.Base;
using BusTicket.Data.Entities;
using BusTicket.Data.Models;
using System.Linq.Expressions;

namespace BusTicket.Data.Interfaces
{
    public class ITripInfo : IBaseRepository<TripInfo, int, TripInfoModel>
    {
        public Task<bool> Exists(Expression<Func<TripInfo, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TripInfoModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TripInfoModel>>> GetAll(Expression<Func<TripInfo, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripInfoModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripInfoModel>> Remove(TripInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripInfoModel>> Save(TripInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TripInfoModel>> Update(TripInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
