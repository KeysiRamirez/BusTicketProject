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
    public class ISeat : IBaseRepository<Seat, int, SeatModel>
    {
        public Task<bool> Exists(Expression<Func<Seat, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<SeatModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<SeatModel>>> GetAll(Expression<Func<Seat, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<SeatModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<SeatModel>> Remove(Seat entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<SeatModel>> Save(Seat entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<SeatModel>> Update(Seat entity)
        {
            throw new NotImplementedException();
        }
    }
}
