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
    public interface IBusDriver : IBaseRepository<BusDriver, int, BusDriverModel>
    {
        //public Task<bool> Exists(Expression<Func<Bus, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<OperationResult<List<BusDriverModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<BusDriverModel>>> GetAll(Expression<Func<BusDriver, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusDriverModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusDriverModel>> Remove(BusDriver entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusDriverModel>> Save(BusDriver entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusDriverModel>> Update(BusDriver entity)
        {
            throw new NotImplementedException();
        }
    }
}
