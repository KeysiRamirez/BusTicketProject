using BusTicket.Domain.Entities;
using BusTicket.Domain.Interfaces;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Models.Trip;
using BusTicket.Persistence.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Persistence.Interfaces
{
    public interface IUser : IRepository<User, int>
    {
        Task<DataResult<UserModel>> GetUser();
        Task<DataResult<UserModel>> GetUser(string name);

    }
}
