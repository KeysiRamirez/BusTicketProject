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
    public class IUser : IBaseRepository<User, int, UserModel>
    {
        public Task<bool> Exists(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<UserModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<UserModel>>> GetAll(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UserModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UserModel>> Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UserModel>> Save(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UserModel>> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
