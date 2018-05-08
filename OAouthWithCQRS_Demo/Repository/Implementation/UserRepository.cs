using CeremonyBazar.Entity;
using CeremonyBazar.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CeremonyBazar.Infrustructure;
using Dapper;
using System.Threading.Tasks;
using CeremonyBazar.Infrustructure.Identity;
using Dapper.Contrib.Extensions;

namespace CeremonyBazar.Repository.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        IConnectionFactory _connectionFactory;
        private const string proc_account_getUserByUserName = "account_getUserByUserName";
        public UserRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<User> GetByName(string userName)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var param = new DynamicParameters();
                param.Add("@UserName", userName);

                var result = connection.QueryFirstOrDefaultAsync<User>(proc_account_getUserByUserName, param, commandType: System.Data.CommandType.StoredProcedure).Result;
                return Task.FromResult(result);
            }
        }

        public Task<User> AddUser(User user)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Insert(user);
                return Task.FromResult(user);
            }
        }
    }
}