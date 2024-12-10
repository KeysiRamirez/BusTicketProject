using BusTicket.Domain.Entities;
using BusTicket.Domain.Models;
using BusTicket.Persistence.Interfaces;
using BusTicket.Persistence.Models.User;
using BusTicket.Persistence.Repository;
using Microsoft.EntityFrameworkCore;


namespace BusTicket.Persistence.Repositories
{
    public sealed class UserRepository : BaseRepository<User, int>, IUser
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<DataResult<UserModel>> GetUser()
        {
            throw new NotImplementedException();
        } 
        public Task<DataResult<UserModel>> GetUser(string name)
        {
            throw new NotImplementedException();
        }

    }
}
