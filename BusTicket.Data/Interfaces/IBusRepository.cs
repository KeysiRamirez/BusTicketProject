using BusTicket.Data.Base;
using BusTicket.Data.Context;
using BusTicket.Data.Entities;
using BusTicket.Data.Models;
using BusTicket.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Interfaces
{
    public interface IBusRepository : IBaseRepository<Bus, int, BusModel>
    {
        //public async Task<bool> Exists(Expression<Func<Bus, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<OperationResult<List<BusModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<List<BusModel>>> GetAll(Expression<Func<Bus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<BusModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<BusModel>> Remove(Bus entity)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<BusModel>> Save(Bus entity)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<BusModel>> Update(Bus entity)
        {
            throw new NotImplementedException();
        }
    }
}
