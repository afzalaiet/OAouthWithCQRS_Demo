using CeremonyBazar.Entity;
using CeremonyBazar.Infrustructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeremonyBazar.Repository.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByName(string userName);

        Task<User> AddUser(User user);
    }
}
