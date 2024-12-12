using BusTicket.Data.Base;
using BusTicket.Data.Entities;
using BusTicket.Data.Models;
using System.Linq.Expressions;



namespace BusTicket.Data.Interfaces
{
    public interface IDriver : IBaseRepository<Driver, int, DriverModel>
    {
        //public Task<bool> Exists(Expression<Func<Driver, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<OperationResult<List<DriverModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<DriverModel>>> GetAll(Expression<Func<Driver, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<DriverModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<DriverModel>> Remove(Driver entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<DriverModel>> Save(Driver entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<DriverModel>> Update(Driver entity)
        {
            throw new NotImplementedException();
        }
    }
}
