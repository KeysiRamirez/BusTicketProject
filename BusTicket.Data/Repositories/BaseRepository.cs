using BusTicket.Data.Base;
using BusTicket.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Repositories
{
    public abstract class BaseRepository<TEntiry, TType, TModel> : IBaseRepository<TEntiry, TType, TModel> where TEntiry : class
    {
        public Task<bool> Exists(Expression<Func<TEntiry, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TModel>>> GetAll(Expression<Func<TEntiry, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TModel>> GetEntityBy(TType Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TModel>> Remove(TEntiry entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TModel>> Save(TEntiry entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TModel>> Update(TEntiry entity)
        {
            throw new NotImplementedException();
        }
    }
}
